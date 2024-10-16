using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullets : Bullet
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        bulletSpeed = 10f;
        rb.velocity = -transform.up * bulletSpeed;
    }

    
}
