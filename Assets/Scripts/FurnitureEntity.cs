using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureEntity : Entity
{
    private void Start()
    {
        currentHp = initialHp;
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

    }

    public override void Die()
    {
        Destroy(gameObject);
    }

}
