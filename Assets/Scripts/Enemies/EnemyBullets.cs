using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBullets : Bullet
{
    private GameObject player;


    public override void Start()
    {
        base.Start();
        bulletSpeed = 30f;
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed;

        Vector3 directoion = player.transform.position - transform.position;


        transform.right = directoion;
        transform.rotation *= Quaternion.Euler(0, 0, -90);
    }
}
