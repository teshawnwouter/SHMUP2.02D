using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Character
{

    public float score;
    
    public int damagerTaken = 1;

    public int healthpoints = 3;

    private void Start()
    {
        health = healthpoints;
        
    }

    private void Update()
    {
        Debug.Log(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            TakeDamage(damagerTaken);
        }
    }


    public override void TakeDamage(int Amount)
    {
        base.TakeDamage(Amount);
        if (health <= 0)
        {

            ScoreBoard.instance.gameObject.SetActive(true);
            ScoreBoard.instance.SetScore(score);

            SceneManager.LoadScene("ScoreBoard");

           
     
            Destroy(gameObject);
        }
    }
}
