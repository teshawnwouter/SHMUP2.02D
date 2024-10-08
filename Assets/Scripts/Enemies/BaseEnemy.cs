using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BaseEnemy : Enemy
{

    private GameObject target;


    public override void Start()
    {
        base.Start();
        target = GameObject.FindGameObjectWithTag("Player");
      

        shootCooldown = 1f;

        StartCoroutine(ShootingPlayer());

    }

    void Update()
    {
        Vector3 directoion = target.transform.position - transform.position;

      
        transform.right = directoion;
        transform.rotation *= Quaternion.Euler(0, 0, -90);
    }

     IEnumerator ShootingPlayer()
     {
        while (true)
        {
            yield return new WaitForSeconds(shootCooldown);

            Instantiate(enemyBullets, enemyAttackPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Instantiate(enemyBullets, enemyAttackPoint.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Instantiate(enemyBullets, enemyAttackPoint.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(shootCooldown);
           
        }
     }
}
