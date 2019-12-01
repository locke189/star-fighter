using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] int damage = 10;
    [SerializeField] GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageUpdate();
        if (healthPoints <= 0)
        {
            DestructionSequence();
        }
    }

    private void DestructionSequence()
    {
        if (explosion) {
            GameObject explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionVFX, explosionVFX.GetComponent<ParticleSystem>().main.duration + explosionVFX.GetComponent<ParticleSystem>().main.startLifetime.constantMax);
        }
        Destroy(gameObject);
    }

    private void DamageUpdate()
    {
        healthPoints -= damage;
    }
}
