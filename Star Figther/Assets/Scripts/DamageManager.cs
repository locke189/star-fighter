using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] int damage = 10;
    [SerializeField] bool isEnemyFire;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var friendlyFire = isEnemyFire == collision.GetComponent<DamageManager>().isEnemyFire;

        if (!friendlyFire) {
            DamageUpdate();
            if (healthPoints <= 0)
            {
                DestructionSequence();
            }
        }
    }

    private void DestructionSequence()
    {
        Destroy(gameObject);
    }

    private void DamageUpdate()
    {
        healthPoints -= damage;
    }
}
