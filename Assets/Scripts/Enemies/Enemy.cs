using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    public int damageTaken = 10;

    public float shootCooldown;

    public GameObject enemyBullets;

    public Transform enemyAttackPoint;



    private void Start()
    {


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(damageTaken);
        }
    }
}
