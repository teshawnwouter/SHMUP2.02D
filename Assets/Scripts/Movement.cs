using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    //making variables that controll the movement and the speed of the Player
    Vector2 moveVector;
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb;

    private void Start()
    {
        //linking the rb
        rb = GetComponent<Rigidbody2D>();
    }
    

    public void OnMoveKeyboard(InputValue value)
    {
        //getting the value to move left and right or in anydirections
        moveVector = value.Get<Vector2>();
    }

    void Update()
    {
        //changing the postion of the character
        rb.MovePosition(rb.position +  moveVector * moveSpeed * Time.deltaTime);
    }
}
