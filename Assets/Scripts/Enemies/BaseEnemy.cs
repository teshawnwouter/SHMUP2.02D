using System.Collections;
using UnityEngine;

public class BaseEnemy : Enemy
{

    private enum State { shooting, none }
    [SerializeField] State state;

    public GameObject enemyBullets;
    public Transform enemyAttackPoint;

    public float shootCooldown;

    private GameObject target;
    protected override void Start()
    {
        base.Start();
        state = State.none;
        health = 40;
        target = GameObject.FindGameObjectWithTag("Player");


        shootCooldown = 6f;
        transform.rotation = Quaternion.Euler(0, 0, 180);


        for (int i = 0; i < waveSpawner.totalWaveIndex/2; i++)
        {
            shootCooldown -= 1.25f;
            if(shootCooldown < 2)
            {
                shootCooldown = 2f;
            }
        }
        StartCoroutine(ShootingPlayer());
    }

    protected override void Update()
    {
        base.Update();
        if (!IsSettingUp && state == State.none)
        {
            state = State.shooting;
        }
        else if (state == State.shooting ) 
        {
           
        }
    }
    IEnumerator ShootingPlayer()
    {
        while (true)
        {
           
            if (!IsSettingUp && state == State.shooting)
            {
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
