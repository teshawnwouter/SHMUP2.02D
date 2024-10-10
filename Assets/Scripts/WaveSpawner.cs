using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private float countdown;

    [SerializeField] private GameObject spawnPoint;
    public int currentWaveIndex = 0;
    public int groupIndex = 0;

    private bool readyToCountDown;
    private bool readyToSpawnWave;

    [SerializeField] private float waveCountDown;

    public Vector2[] spawnPoints;
    //een array link aan de waves class
    public wave[] waves;

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
            return;
        }

        if(groupIndex >= waves[currentWaveIndex].groups.Length)
        {
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
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].groups[groupIndex].enemies.Length; i++)
            {
                spawnPoint.transform.position = spawnPoints[i];
                Enemy enemies = Instantiate(waves[currentWaveIndex].groups[groupIndex].enemies[i], spawnPoint.transform.position = (new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z)), Quaternion.identity);
                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemey);
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
    public Enemy[] enemies;

    public int enemiesleft;

}
