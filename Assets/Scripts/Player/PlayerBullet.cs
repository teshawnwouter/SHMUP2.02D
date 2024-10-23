using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    Player player;


    Shooting shooting;

    public GameObject blackHole;
   public override void Start()
    {
        base.Start();


        shooting = FindObjectOfType<Shooting>();
        Debug.Log(shooting);
        player = FindObjectOfType<Player>();
        bulletSpeed = 10f;
        rb.velocity = transform.up * bulletSpeed;
        damage = 10;
        damage += player.weaponBoost;
   }


    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (shooting.fireMode == Shooting.FireMode.blackHole)
        { 
            Instantiate(blackHole,transform.position,Quaternion.identity);
            shooting.chargPower = 0;
            shooting.fireMode = Shooting.FireMode.charging;
        }
    }
}
