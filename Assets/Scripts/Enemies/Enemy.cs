using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int damageTaken = 10;
   
    public WaveSpawner waveSpawner;


    public virtual void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(damageTaken);
        }
    }

    public override void TakeDamage(int Amount)
    {
        base.TakeDamage(Amount);
        if (health <= 0)
        {
            waveSpawner.waves[waveSpawner.currentWaveIndex].groups[waveSpawner.groupIndex].enemiesleft--;

            Destroy(gameObject);

            
        }
    }
}
