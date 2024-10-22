using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class Player : Character
{

    private enum State { normal, shielded, cantBeShielded }

    [SerializeField] State state;

    PlayerControler playerControler;

    public float regenSpeed;
    [SerializeField] private bool ableToRegen;
    public bool activeRegen;
    public float maxRegenTime;


    public float shieldDuration;
    [SerializeField] private float shieldCooldown;

    public int weaponBoost;

    public List<PowerUps> powerUp = new List<PowerUps>();


    WaveSpawner waveSpawner;


    //link aan de waves en zet een item in na x aantal waves

    public float score;

    public int damagerTaken = 1;

    public int healthpoints = 3;

    private void Awake()
    {
        playerControler = new PlayerControler();

        playerControler.PCInputmanager.Shield.performed += Shield_performed;
        playerControler.PCInputmanager.Enable();

        health = healthpoints;
    }

    private void Shield_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (powerUp.Exists(p => p.Type == PowerUps.PowerupType.Shield))
        {
            if (state == State.normal)
            {
                StartCoroutine(IsShieldingPlayer());
            }
        }
    }

    private void Start()
    {
        shieldCooldown = 5f;

        state = State.normal;

        activeRegen = false;
        ableToRegen = false;


        waveSpawner = FindObjectOfType<WaveSpawner>();
        waveSpawner.PlayerObject = this;
        AddRandomPowerup();
    }

    public void AddRandomPowerup()
    {
        PowerUps _newPowerup = PowerUpManager.Instance.GetRandomPowerup();
        switch (_newPowerup.Type)
        {
            default:
                AddPowerup(_newPowerup);
                break;

            case PowerUps.PowerupType.Shield:
            case PowerUps.PowerupType.Regen:
                if (powerUp.Find(p => p.Type == PowerUps.PowerupType.Shield || p.Type == PowerUps.PowerupType.Regen) == null)
                {
                    AddPowerup(_newPowerup);
                }
                break;
        }
    }

    private void AddPowerup(PowerUps powerup)
    {
        powerUp.Add(powerup);
        powerup.Aply(this.gameObject);
    }


    private void Update()
    {
        if (powerUp.Exists(p => p.Type == PowerUps.PowerupType.Regen))
        {
            if (health < healthpoints)
            {
                GainingHealth();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet") && state == State.normal)
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

    IEnumerator IsShieldingPlayer()
    {
        if (state == State.normal)
        {
            state = State.shielded;
            yield return new WaitForSeconds(shieldDuration);
            state = State.cantBeShielded;
           
        }
        if(state == State.cantBeShielded)
        {
            yield return new WaitForSeconds(shieldCooldown);
            state= State.normal;
        }
    }
}
