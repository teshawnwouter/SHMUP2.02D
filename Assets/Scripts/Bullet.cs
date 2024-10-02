using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private Rigidbody2D rb;

    private float bulletSpeed = 10f;
    void Start()
    {
        GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(Vector2.up * bulletSpeed);
        Destroy(this.gameObject, 3f);
    }
}
