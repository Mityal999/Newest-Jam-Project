using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float initialHp;
    public float currentHp;

    public float immunityTime;
    public bool isImmune = false;



    public abstract void OnTriggerEnter(Collider other);
    
    protected void TryRecieveDamage(float damage)
    {
        if (isImmune)
        {
            //do nothing
        }
        else
        {
            RecieveDamage(damage);
            //Debug.Log(damage);
        }
    }
    protected void RecieveDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Die();
        }
        else
        {
            isImmune = true;
            StartCoroutine("ImmunityTimer");
            OnDamageRecieved(damage);
        }

    }

    public abstract void OnDamageRecieved(float damage);

    public IEnumerator ImmunityTimer()
    {
        yield return new WaitForSeconds(immunityTime);

        isImmune = false;
    }

    public abstract void Die();
}
