using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    Player player;
   public override void Start()
    {
        base.Start();
        player = FindObjectOfType<Player>();
        bulletSpeed = 10f;
        rb.velocity = transform.up * bulletSpeed;
        damage = player.weaponBoost;
   }
}
