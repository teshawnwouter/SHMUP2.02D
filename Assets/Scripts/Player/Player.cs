using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Character
{

    [SerializeField] private List<PowerUp> powerUp = new List<PowerUp>();

    WaveSpawner waveSpawner;
    //link aan de waves en zet een item in na x aantal waves

    public float score;
    
    public int damagerTaken = 1;

    public int healthpoints = 3;

    private void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();

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


    public void GaingingPowerUps()
    {
        for (int i = 0; i < waveSpawner.totalWaveIndex /2; i++) 
        {
            //if(powerUp.Contains == powerUp)
            //{
            //    powerUp.Add;
            //}
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
