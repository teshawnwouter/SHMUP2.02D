using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Character
{
    public int damagerTaken = 1;

    public int healthpoints = 3;

    private void Start()
    {
        health = healthpoints;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(damagerTaken);
        }
    }
}
