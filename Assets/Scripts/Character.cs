using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Character : MonoBehaviour
{
    float damageTaken;


    public int health;
    public virtual void TakeDamage(int Amount)
    {

        health -= Amount;
        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
