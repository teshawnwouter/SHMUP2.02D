using System.Collections;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    
    [SerializeField] private float countdown;
  
    [SerializeField] private GameObject spawnPoint;
    public int currentWaveIndex = 0;
    public int groupIndex = 0;  
    
    private bool readyToCountDown;


    //een array link aan de waves class
    public wave[] waves;

    void Start()
    {
        
        readyToCountDown = true;
        
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; i < waves[i].groups.Length; j++)
            {
                waves[i].groups[j].enemiesleft = waves[i].groups[j].enemies.Length;
                Debug.Log(waves[i].groups[j].enemiesleft);
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
                currentWaveIndex++;
                groupIndex = 0;

            }

         }

        IEnumerator SpawnWave()
        {
            if (currentWaveIndex < waves.Length)
            {
                for (int i = 0; i < waves[currentWaveIndex].groups.Length; i++)
                {
                    Enemy enemies = Instantiate(waves[currentWaveIndex].groups[groupIndex].enemies[i], spawnPoint.transform);
                    enemies.transform.SetParent(spawnPoint.transform);

                    yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemey);
                }
            }
        }

    private void GroupSpawner()
    {
        if(groupIndex < waves[currentWaveIndex].groups.Length)
        {
            for(int i = 0; i < waves[currentWaveIndex].groups.Length; i++) 
            { 

            }
        }
    }
}
    


//om de enemies waves temaken maken we serializable
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

    [HideInInspector] public int enemiesleft;

}
