using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackItem : MonoBehaviour
{
    public float maxDamage;

    public float accelerationTime;
    public float colliderOffTime;
    public float relaxationTime;

    private bool isAttacking = false;

    public Collider itemCollider;
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
        Debug.Log(mul);
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

        StartCoroutine("WaitForColliderDisabling");
    }

    public IEnumerator WaitForColliderDisabling()
    {
        yield return new WaitForSeconds(colliderOffTime);

        itemCollider.enabled = false;

        StartCoroutine("WaitForNextHitReadiness");
    }

    public IEnumerator WaitForNextHitReadiness()
    {
        yield return new WaitForSeconds(relaxationTime);

        itemCollider.enabled = true;
        isAttacking = false;
    }


}
