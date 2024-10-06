using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    public override void Start()
    {
        base.Start();
        bulletSpeed = 10f;
        rb.velocity = transform.up * bulletSpeed;
    }
}
