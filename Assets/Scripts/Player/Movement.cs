using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

[RequireComponent(typeof(PlayerInput))]
public class Movement : MonoBehaviour
{
    //making variables that controll the movement and the speed of the Player en de rigidbody2D en ook de controlls aangemaakt in unity
    [SerializeField] private float moveSpeed;
    Rigidbody2D rb;
   
    private PlayerControler playerControler;

    private void Awake()
    {
        //linken de rigidbody aan het component  maken new controls aam waar wij een functie laten maken voor de keyboard movement
        rb = GetComponent<Rigidbody2D>();

        playerControler = new PlayerControler();


        playerControler.PCInputmanager.MoveKeyboard.Enable();
      
    }

    //verander je update naar fixedUpdated en maak ene vector2 aan die de input leest als hij hem leest dan zet je velocity aan de rigitbody zijn x pos maal de snelheid
    void FixedUpdate()
    {
        Vector2 playerInput = playerControler.PCInputmanager.MoveKeyboard.ReadValue<Vector2>();

        rb.velocity = new Vector2(playerInput.x * moveSpeed, 0);
    }
}
