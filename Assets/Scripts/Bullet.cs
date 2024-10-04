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
        rb.velocity = transform.up * bulletSpeed;
    }

    void Update()
    {
        Destroy(this.gameObject, 3f);
    }
}
