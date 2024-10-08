using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    //maken een link aan de rigidBody2D een een snelheid voor de kogle
    public Rigidbody2D rb;

    public float bulletSpeed;
    public virtual void Start()
    {
        //liken de rigidbody aan het component en het een velocity om te bewegen een keer
        GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //na 3 seconden vernietigen we het object
        Destroy(this.gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
