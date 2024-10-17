using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Character
{
    public int damageTaken = 10;
    private Vector2 m_InitPos;
    protected bool IsSettingUp;

    public WaveSpawner waveSpawner;

    public float scoreGiven = 3;

    Player player;

    protected float rightSideOfTheScreen;
    protected float leftSideOfTheScreen;

    protected float topSideOfTheScrean;
    protected float bottomSideOfTheScrean;

    protected virtual void Start()
    {
        waveSpawner = FindObjectOfType<WaveSpawner>();
        IsSettingUp = true;

        rightSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        leftSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;


        bottomSideOfTheScrean = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height/2)).y;
        topSideOfTheScrean = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height - 4)).y;

        m_InitPos.x = Random.Range(leftSideOfTheScreen, rightSideOfTheScreen);
        m_InitPos.y = Random.Range(bottomSideOfTheScrean,topSideOfTheScrean);

    }

    protected virtual void Update()
    {
        if (IsSettingUp)
            GoToInit();
    }

    private void GoToInit()
    {
        transform.position = Vector2.Lerp(transform.position, m_InitPos, Time.deltaTime);
        if (Vector2.Distance(transform.position, m_InitPos) < 0.1f)
        {
            IsSettingUp = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            TakeDamage(damageTaken);
        }
    }

    public override void TakeDamage(int Amount)
    {
        if (!IsSettingUp)
            base.TakeDamage(10);

        if (health <= 0)
        {
            player.score += scoreGiven;
            waveSpawner.waves[waveSpawner.currentWaveIndex].groups[waveSpawner.groupIndex].enemiesleft--;
            Destroy(gameObject);
        }
    }
}
