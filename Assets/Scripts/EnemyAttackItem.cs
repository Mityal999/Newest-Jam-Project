using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackItem : MonoBehaviour
{
    public float damage;
    public float accelerationTime;
    public float relaxationTime;

    private bool isAttacking = false;

    private HingeJoint hinge;

    private void Start()
    {
        hinge = gameObject.GetComponent<HingeJoint>();
    }



    public float GetCurrentDamage()
    {
        return damage;
    }



    public void TryAttack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            Attack();
        }
    }

    public void Attack()
    {
        StartCoroutine("Sway");
    }

    public IEnumerator Sway()
    {
        hinge.useSpring = false;
        hinge.useMotor = true;
        var motor = hinge.motor;

        yield return new WaitForSeconds(accelerationTime);

        hinge.useSpring = true;
        hinge.useMotor = false;

        EndAttack();
    }

    private void EndAttack()
    {
        StartCoroutine("WaitForRelaxation");
    }

    public IEnumerator WaitForRelaxation()
    {
        yield return new WaitForSeconds(relaxationTime);

        isAttacking = false;
    }


}
