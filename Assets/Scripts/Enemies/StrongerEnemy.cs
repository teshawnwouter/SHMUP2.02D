using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Rigidbody2D))]
public class StrongerEnemy : Enemy
{
    private enum State { none, attacking}

    private State state;

    private Rigidbody2D rb;
    private GameObject enemy;
    public Transform enemyAttackPoint;
    public GameObject enemyBullets;

    private float flySpeed;
    private bool movingLeft = false;
    private float  shootDelay;
    protected override void Start()
    {
        base.Start();
       

        state = State.none;

        health = 60;
        flySpeed = 3f;
        shootDelay = 6f;
        enemy = GameObject.FindGameObjectWithTag("Player");
        

        transform.rotation = Quaternion.Euler(0, 0, -180);
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < waveSpawner.totalWaveIndex / 2; i++)
        {
            flySpeed *= 1.5f;
            shootDelay -= 1.25f;
        }
        StartCoroutine(ShootingPlayer());

    }


    protected override void Update()
    {
        Debug.Log(scoreGiven);
        base.Update();

        if (!IsSettingUp && state == State.none)
        {
            state = State.attacking;
        }
        else if (state == State.attacking) 
        {
            if(enemy != null)
            {
                MoveLeftAndRight();
                transform.up = enemy.transform.position - transform.position;
            }
        }
    }


    private void MoveLeftAndRight()
    {
        if (!movingLeft)
        {
            rb.velocity = new Vector2(1 * flySpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-1 * flySpeed, 0);
        }

        if (transform.position.x > rightSideOfTheScreen)
        {
            movingLeft = true;
        }
        else if (transform.position.x < leftSideOfTheScreen)
        {
            movingLeft = false;
        }
    }
    IEnumerator ShootingPlayer()
    {
        while (true)
        {

            if (!IsSettingUp && state == State.attacking)
            {
                ShootingBullets();
                yield return new WaitForSeconds(shootDelay);
            }
            else
                yield return new WaitForEndOfFrame();


        }
    }

    private void ShootingBullets()
    {
        Instantiate(enemyBullets, enemyAttackPoint.transform.position, Quaternion.identity);
    }



}
