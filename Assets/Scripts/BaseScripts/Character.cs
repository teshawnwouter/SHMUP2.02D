using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Character : MonoBehaviour
{
    public int health;

    
  
    public virtual void TakeDamage(int Amount)
    {

        health -= Amount;
        if(health <= 0)
        {

        }

    }

    public virtual void AddingScores(int Amount)
    {

    }
}
