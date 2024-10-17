using System.Collections;
using UnityEngine;

public class BossEnemy : Character
{
    private enum State { settingUp, normal, enraged }

    [SerializeField] State state;

    private int normaldamageTaken = 5;
    private int enrageddamageTaken = 2;

    private bool IsSettingUp;
    public WaveSpawner waveSpawner;

    private Vector2 m_InitPos;

    int rageHealth;

    public GameObject bullets;
    float fireRateForNormal = 5f;
    float fireRateForRage = 3f;

    private float topSideOfTheScreen;
    private float middleOfTheTop;

    void Start()
    {
        IsSettingUp = true;
        health = 100;
        rageHealth = health / 2;
        Debug.Log(rageHealth);


        state = State.settingUp;
        waveSpawner = FindObjectOfType<WaveSpawner>();

        topSideOfTheScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height - 100)).y;
        middleOfTheTop = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width / 2, Screen.height)).x;

        m_InitPos.x = middleOfTheTop;
        m_InitPos.y = topSideOfTheScreen;


        for (int i = 0; i < waveSpawner.totalWaveIndex; i++)
        {
            health += 60;
            fireRateForNormal -= .5f;
            if (fireRateForNormal < 2)
                fireRateForNormal = 2f;

            fireRateForRage -= .5f;
            if (fireRateForRage < .75f)
                fireRateForRage = .75f;

        }
        StartCoroutine(ShootingAtTarget());


    }


    void Update()
    {
        Debug.Log();
        if (IsSettingUp)
            GoToInit();

        if (!IsSettingUp && health <= rageHealth)
        {
            state = State.enraged;
        }
    }

    private void GoToInit()
    {
        transform.position = Vector2.Lerp(transform.position, m_InitPos, Time.deltaTime);
        if (Vector2.Distance(transform.position, m_InitPos) < 0.1f)
        {
            IsSettingUp = false;
            state = State.normal;
        }
    }
    IEnumerator ShootingAtTarget()
    {
        while (true)
        {
            if (!IsSettingUp && state == State.normal)
            {
                AttackingNormal();
                yield return new WaitForSeconds(fireRateForNormal);
            }
            else if (!IsSettingUp && state == State.enraged)
            {
                AttackingNormal();
                yield return new WaitForSeconds(fireRateForRage);
            }
            else
                yield return new WaitForEndOfFrame();
        }
    }

    private void AttackingNormal()
    {
        Instantiate(bullets, transform.position, Quaternion.identity);
    }


    public override void TakeDamage(int Amount)
    {
        if (!IsSettingUp)
            base.TakeDamage(Amount);

        if (health <= 0)
        {
            waveSpawner.waves[waveSpawner.currentWaveIndex].groups[waveSpawner.groupIndex].enemiesleft--;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            if ((state == State.normal))
            {
                TakeDamage(normaldamageTaken);
            }
            else if ((state == State.enraged))
            {
                TakeDamage(enrageddamageTaken);
            }

        }
    }
}
