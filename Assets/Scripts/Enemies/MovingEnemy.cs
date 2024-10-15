using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingEnemy : Enemy
{
    private enum State {  leftAndRight, upAndDown, none }
    [SerializeField] private State state;


    private Rigidbody2D rb;
    bool movingLeft = false;

    bool movingUp = false;

    [SerializeField] private float moveSpeed;

    protected override void Start()
    {
        base.Start();
        moveSpeed = 3f;

        for (int i = 0; i < waveSpawner.totalWaveIndex/4; i++)
        {
            moveSpeed = moveSpeed * 2;
            health = health + 20;
        }
        Debug.Log(moveSpeed);

        transform.rotation = Quaternion.Euler(0, 0, -180);

        rb = GetComponent<Rigidbody2D>();

        health = 20;


        state = State.none;
    }


    protected override void Update()
    {

       
        base.Update();
        if (!IsSettingUp && state == State.none)
        {
            int stateCaller = Random.Range(0, 2);
            if (stateCaller == 0)
            {
                state = State.leftAndRight;
            }
            else
            {
                state = State.upAndDown;
            }
        }

        switch (state)
        {
            case State.upAndDown:
                MoveUpAndDown();
                break;
            case State.leftAndRight:
                MoveLeftAndRight();
                break;
        }
    }



    private void MoveLeftAndRight()
    {
        if (!movingLeft)
        {
            rb.velocity = new Vector2(1 * moveSpeed, 0);
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);

        }
        else
        {
            rb.velocity = new Vector2(-1 * moveSpeed, 0);
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);

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

    private void MoveUpAndDown()
    {
        float topSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

        if (!movingUp)
        {
            rb.velocity = new Vector2(0, 1 * moveSpeed);
            transform.rotation = Quaternion.Euler(0f, 0, 0);

        }
        else
        {
            rb.velocity = new Vector2(0, -1 * moveSpeed);
            transform.rotation = Quaternion.Euler(0f, 0, -180f);


        }

        if (transform.position.y > topSideOfTheScreen)
        {
            movingUp = true;
        }
        else if (transform.position.y < bottomSideOfTheScreen)
        {
            movingUp = false;
        }
    }

}
