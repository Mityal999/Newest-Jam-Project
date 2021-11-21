using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyEntity : Entity
{
    public EnemyAttackItem attackItem;
    private NavMeshAgent agent;
    public GameObject playerObj;

    public float chaseDistance;
    public float attackDistance;

    public GameObject deathParticleObj;
    public GameObject damageParticleObj;
    public float turnSpeedOnAttack;

    private void Start()
    {
        currentHp = initialHp;

        agent = gameObject.GetComponent<NavMeshAgent>();
    }



    private void FixedUpdate()
    {
        //Рассчитать расстояние до игрока и преследовать его, если оно мало
        float distanceToPlayer = (playerObj.transform.position - gameObject.transform.position).magnitude;
        if (distanceToPlayer < chaseDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(playerObj.transform.position);
        }
        if (distanceToPlayer < attackDistance)
        {
            agent.isStopped = true;
            attackItem.TryAttack();

            Vector3 dir = playerObj.transform.position - transform.position;
            dir.Normalize();
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeedOnAttack);
        }
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerWeapon")
        {
            PlayerAttackItem attackItem = other.gameObject.GetComponentInParent<PlayerAttackItem>();
            float damageToRecieve = attackItem.GetCurrentDamage();
            TryRecieveDamage(damageToRecieve);
        }
    }

    public override void OnDamageRecieved(float damage)
    {
        damageParticleObj.SetActive(false);
        damageParticleObj.SetActive(true);
    }

    public override void Die()
    {
        deathParticleObj.SetActive(false);
        deathParticleObj.SetActive(true);

        StartCoroutine("SceduledDeath");
    }


    public IEnumerator SceduledDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }


}
