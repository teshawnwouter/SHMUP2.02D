using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrapper : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
      Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        float rightSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfTheScreen =  Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x;

        if (screenPos.x <= 0 && rb.velocity.x < 0)
        {
            Debug.Log("should teleport");
            transform.position = new Vector2(rightSideOfTheScreen, transform.position.y);
        }else if (screenPos.x >= Screen.width && rb.velocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfTheScreen, transform.position.y);
        }
    }
}
