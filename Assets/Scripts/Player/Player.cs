using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Character
{

    public float regenSpeed;
    [SerializeField] private bool ableToRegen;
    public bool activeRegen;
    public float maxRegenTime;

    

    public List<PowerUps> powerUp = new List<PowerUps>();

    WaveSpawner waveSpawner;
    //link aan de waves en zet een item in na x aantal waves

    public float score;

    public int damagerTaken = 1;

    public int healthpoints = 3;

    private void Awake()
    {
        health = healthpoints;
    }

    private void Start()
    {
        activeRegen = false;
        ableToRegen = false;


        waveSpawner = FindObjectOfType<WaveSpawner>();
    }

    private void Update()
    {
        
        foreach (var powerup in powerUp)
        {
            if (powerUp.Contains(powerup))
            {
                if (powerup.name == "regen" && health < healthpoints)
                {
                    GainingHealth();
                }
            }

        }
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

    private void GainingHealth()
    {


        if (health < healthpoints)
        {
            ableToRegen = true;
        }

        if (ableToRegen == true)
        {
            regenSpeed -= Time.deltaTime;
            ableToRegen = false;
        }

        if (health <= healthpoints && regenSpeed <= 0)
        {
            health++;
         
            regenSpeed = maxRegenTime;
        }
    }
}
