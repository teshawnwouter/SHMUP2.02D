using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingEnemy : Enemy
{
    private enum State { leftAndRight, upAndDown}
    [SerializeField] private State state;

    private Rigidbody2D rb;

    bool movingLeft = false;


    [SerializeField]private float moveSpeed = 10f;
    public override void Start()
    {
        base.Start();

        int stateCaller = Random.Range(0, 1);

        rb = GetComponent<Rigidbody2D>();

        health = 20;

        if(stateCaller == 0)
        {
            state = State.leftAndRight;
        }else
        {
            state = State.upAndDown;
        }

       
    }


    private void Update()
    {
        if (state == State.leftAndRight)
        {
            MoveLeftAndRight();
        }
        else
        {
            MoveUpAndDown();
        }
    }

    private void MoveLeftAndRight()
    {
        if(!movingLeft)
        {
            rb.velocity = new Vector2(1 * moveSpeed * Time.deltaTime, 0);
        } else
        {
            rb.velocity = new Vector2(-1 * moveSpeed * Time.deltaTime, 0);
        }
        


        float rightSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

        if (transform.position.x > rightSideOfTheScreen)
        {
            Debug.Log("moving left");
            //rb.velocity = new Vector2(1 * moveSpeed * Time.deltaTime, 0);
            movingLeft = true;
            //transform.rotation.SetEulerRotation(new Vector3(0f, 0f, -90f));
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        }
        else if (transform.position.x < leftSideOfTheScreen)
        {
            Debug.Log("moving right");
            //rb.velocity = new Vector2(1 * -moveSpeed * Time.deltaTime, 0);
            movingLeft = false;
            transform.rotation = Quaternion.Euler(0f, 0f, -90f);
        }




    }

    private void MoveUpAndDown()
    {
        float topSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

    }

}
