using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackItem : MonoBehaviour
{
    public float maxDamage;

    public float accelerationTime;
    public float relaxationTime;

    private bool isAttacking = false;

    public Rigidbody damagingPartRb;
    private HingeJoint hinge;
    private AttackHitSoundSystem soundSystem;

    private void Start()
    {
        hinge = gameObject.GetComponent<HingeJoint>();
        damagingPartRb = gameObject.GetComponent<Rigidbody>();
        soundSystem = gameObject.GetComponent<AttackHitSoundSystem>();
    }



    public float GetCurrentDamage()
    {
        float mul = damagingPartRb.velocity.magnitude;
        float normalizedMul = 0f;

        if (mul < 1f)
        {
            normalizedMul = 0f;
            soundSystem.PlayWeakHit();
        }
        else if (mul < 6f)
        {
            normalizedMul = 1f;
            soundSystem.PlayNormalHit();
        }
        else
        {
            normalizedMul = 4f;
            soundSystem.PlayStrongHit();
        }

        return normalizedMul * maxDamage;       
    }



    public void TryAttack()
    {
        if (isAttacking)
        {
            //do nothing
        }
        else
        {
            isAttacking = true;
            Attack();
        }
    }

    public void Attack()
    {
        soundSystem.PlaySway();
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
