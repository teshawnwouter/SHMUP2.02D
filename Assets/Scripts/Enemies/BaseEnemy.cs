using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseEnemy : Enemy
{
    public GameObject enemyBullets;
    public Transform enemyAttackPoint;

    public float shootCooldown;

    private GameObject target;


    protected override void Start()
    {
        base.Start();

        health = 40;
        target = GameObject.FindGameObjectWithTag("Player");


        shootCooldown = 1f;

        StartCoroutine(ShootingPlayer());

    }

    protected override void Update()
    {
        base.Update();
        transform.up = target.transform.position - transform.position; ;
    }

    IEnumerator ShootingPlayer()
    {
        while (true)
        {
            if (!IsSettingUp)
            {
                yield return new WaitForSeconds(shootCooldown);
                //for()
                ShootingBullets();
                yield return new WaitForSeconds(shootCooldown);
            }
            else
                yield return new WaitForEndOfFrame();

        }
    }

    private void ShootingBullets()
    {
        Instantiate(enemyBullets, enemyAttackPoint.transform.position, Quaternion.identity);
    }
}
