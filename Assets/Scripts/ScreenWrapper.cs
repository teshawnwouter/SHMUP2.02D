using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//new geleerdt om componnenten verplicht te maken op objecten
[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapper : MonoBehaviour
{
    //benoemen de rigidbody2D
    private Rigidbody2D rb;

    void Start()
    {
        //linken de rigidBody2D aan  het script
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // nemen het scherm positie op de echte wereld van de main camera
      Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //maken floats voor de linkerkant en de rechter kan van het scherm
        float rightSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfTheScreen =  Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x;
        //kijken of het object aan de linker kantbent enbeweegt dan zetten die op de positie van de andere kan
        if (screenPos.x <= 0 && rb.velocity.x < 0)
        {
            transform.position = new Vector2(rightSideOfTheScreen, transform.position.y);
            //kijken of je aan de rechter kant bent kan ben en beweegt dan moven we je naar de anderekant
        }else if (screenPos.x >= Screen.width && rb.velocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfTheScreen, transform.position.y);
        }
    }
}
