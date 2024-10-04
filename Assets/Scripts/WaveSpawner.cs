using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private float countdown;

    [SerializeField]
    private GameObject spawnPoint;
    public int currentWaveIndex = 0;

    private bool readyToCountDown;



    public wave[] waves;


    void Start()
    {
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesleft = waves[i].enemies.Length;
        }


    }

    void Update()
    {


        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("you dit it!!");
            return;
        }

        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextEnemey;
            StartCoroutine(SpawnWave());
        }
        if (waves[currentWaveIndex].enemiesleft == 0)
        {
            currentWaveIndex++;
        }
    }

    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Enemy enemies = Instantiate(waves[currentWaveIndex].enemies[i], spawnPoint.transform);
                enemies.transform.SetParent(spawnPoint.transform);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemey);
            }
        }
    }
}


[System.Serializable]

public class wave
{
    public Enemy[] enemies;
    public float timeToNextEnemey;
    public float timeToNectWave;

    [HideInInspector]
    public int enemiesleft;

}
