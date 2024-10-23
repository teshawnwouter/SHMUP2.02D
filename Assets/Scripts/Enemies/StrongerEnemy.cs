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

    public bool canMove = true;

    private float flySpeed;
    private bool movingLeft = false;
    private float  shootDelay;
    protected override void Start()
    {
        base.Start();
        canMove = true;

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
        base.Update();

        if (!IsSettingUp && state == State.none && enemyState == EnemyState.normal)
        {
            state = State.attacking;
        }
        else if (state == State.attacking && enemyState == EnemyState.normal) 
        {
            if(enemy != null && enemyState == EnemyState.normal)
            {
                transform.up = enemy.transform.position - transform.position;
            }
            MoveLeftAndRight();

        }
        

        if (enemyState == EnemyState.beingPulled) 
        {
            canMove = false;

            MoveLeftAndRight();
        }else
        {
            canMove = true;
        }

    }


    private void MoveLeftAndRight()
    {
        if (!movingLeft && canMove)
        {
            rb.velocity = new Vector2(1 * flySpeed, 0);
        }
        else if(movingLeft && canMove)
        {
            rb.velocity = new Vector2(-1 * flySpeed, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
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

            if (!IsSettingUp && state == State.attacking && enemyState == EnemyState.normal)
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
