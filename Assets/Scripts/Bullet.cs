using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //maken een link aan de rigidBody2D een een snelheid voor de kogle
    [SerializeField]private Rigidbody2D rb;

    private float bulletSpeed = 10f;
    void Start()
    {
        //liken de rigidbody aan het component en het een velocity om te bewegen een keer
        GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        //na 3 seconden vernietigen we het object
        Destroy(this.gameObject, 3f);
    }
}
