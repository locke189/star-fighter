using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageManager : MonoBehaviour
{
    [SerializeField] int healthPoints = 10;
    [SerializeField] int damage = 10;
    [SerializeField] GameObject explosion;
    [SerializeField] FloatVariable PlayerScore;
    [SerializeField] float score;

    public UnityEvent OnObjectDestroyed;

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
        OnObjectDestroyed.Invoke();
        if (explosion) {
            GameObject explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(explosionVFX, explosionVFX.GetComponent<ParticleSystem>().main.duration + explosionVFX.GetComponent<ParticleSystem>().main.startLifetime.constantMax);
        }

        if (PlayerScore) {
            PlayerScore.value += 10;
        }

        Destroy(gameObject);
    }

    private void DamageUpdate()
    {
        healthPoints -= damage;
    }
}
