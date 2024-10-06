using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Enemy
{
    GameObject target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
       

        shootCooldown = 1f;

        StartCoroutine(ShootingPlayer());
    }


    void Update()
    {
        
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
