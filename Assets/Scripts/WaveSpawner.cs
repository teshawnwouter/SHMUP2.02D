using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;

    [SerializeField] private GameObject spawnPoint;
    public int currentWaveIndex = 0;
    public int groupIndex = 0;

    public int totalWaveIndex = 0;

    private bool readyToCountDown;
    private bool readyToSpawnWave;

    [SerializeField] private float waveCountDown;

    public wave[] waves;

    public int numberOfEnemies;

    [SerializeField] private GameObject[] enemyTypes;

    void Start()
    {
        readyToSpawnWave = true;
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; j < waves[i].groups.Length; j++)
            {
                waves[i].groups[j].enemiesleft = waves[i].groups[j].enemies.Length;
            }


        }

}

    void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            currentWaveIndex = 0;
            for (int i = 0; i < waves.Length; i++)
            {
                for (int j = 0; j < waves[i].groups.Length; j++)
                {
                    waves[i].groups[j].enemiesleft = waves[i].groups[j].enemies.Length;
                }
            }
        }

        if (currentWaveIndex < waves.Length) 
        {
           
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
        if (waves[currentWaveIndex].groups[groupIndex].enemiesleft == 0)
        {
            readyToCountDown = true;
            groupIndex++;

        }

        if (groupIndex == waves[currentWaveIndex].groups.Length)
        {
            readyToSpawnWave = true;
            groupIndex = 0;
            currentWaveIndex++;
            totalWaveIndex++;
        }

        if (readyToSpawnWave == true)
        {
            waveCountDown -= Time.deltaTime;
        }

        if (waveCountDown <= 0)
        {
            readyToSpawnWave = false;

            waveCountDown = waves[currentWaveIndex].timeToNextEnemey;
        }

    }

    IEnumerator SpawnWave()
    {
        numberOfEnemies = Random.Range(3, 7);

        if(groupIndex == 3) 
        {
            numberOfEnemies = 1;
        }
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                Character enemies = Instantiate(waves[currentWaveIndex].groups[groupIndex].enemies[Random.Range(0, waves[currentWaveIndex].groups[groupIndex].enemies.Length)], spawnPoint.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemey);

                waves[currentWaveIndex].groups[groupIndex].enemiesleft = numberOfEnemies;
            }
        }
    }

}


    [System.Serializable]
    public class wave
    {
        public Groups[] groups;
        public float timeToNextEnemey;
        public float timeToNectWave;



    }

    [System.Serializable]
    public class Groups
    {
        public Character[] enemies;

        public int enemiesleft;

    }
