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


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //    if (collision.gameObject.CompareTag("EnemyBullet"))
    //    {
    //        TakeDamage(damagerTaken);
    //    }
    //}


    public override void TakeDamage(int Amount)
    {
        base.TakeDamage(Amount);
        if (health <= 0)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
