using System.Collections;
using System.Linq;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    //maak een float aan voor de coundown van waneer de wave spawned
    [SerializeField] private float countdown;
    //maak een empty object die de spawnpunt van de enemies heeft een een index dat alle enemies van de wave telt
    [SerializeField] private GameObject spawnPoint;
    public int currentWaveIndex = 0;
    public int groupIndex = 0;  
    //een bool voor waneer hij de countdown ma starten
    private bool readyToCountDown;


    //een array link aan de waves class
    public wave[] waves;

    void Start()
    {
        //aan het begin van de game zet je de countdown op true zodat hij teld
        readyToCountDown = true;
        //maken een loop om tekijken hoeveel enemies er nog zijn
        for (int i = 0; i < waves.Length; i++)
        {
            for (int j = 0; i < waves[i].groups.Length; j++)
            {
                waves[i].groups[j].enemiesleft = waves[i].groups[j].enemies.Length;
            }
            //zet de waves array lengte die teld hoeveel enemies er zijn gelijk aan de enemies in de loop om bijtehouden dat dat de aantal enemies overzijn        }


        }
    }

         void Update()
         {
            // kijken of het aantal enemies kleiner is aan de max aantal mensen in de wave en returnen hem als hij kleiner is of gelijk is aan 0
            if (currentWaveIndex >= waves.Length)
            {
                return;
            }
            //kijken of de countdown true is als hij true is trekken we tijd van hem af
            if (readyToCountDown == true)
            {
                countdown -= Time.deltaTime;
            }
            //als de countdown op 0 is maken hem uit en maken hem gelijk aan de waves en de tijd voor dat de volgende enemy mag spawnen
            //we roepen een spawn functie aan als coroutine
            //en als de huidigen wave gelijk zijn enemiies gelijk is aan o tellen we 1 op bij de current wave om de volgende te spawnen
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
            //kijken of current wave indext kleiner is dan hoeveel er max zijn
            //maak een loop die de wave index het max aantal waves vast houdt
            //linken we het Enmy script en spawn in elk object die de enemie script heeft gelijk aan hoeveel enemies in de wave zijn gegooit 
            // maak hijn parant de spawn point zodat je ze er omheen kan spawnen
            //en wacht op de current aantal het tijd voor de volgende enemie mag spawnen als de wave index niet leeg is
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
        if(groupIndex < waves.groups.enemies)
        {

        }
    }
}
    


//om de enemies waves temaken maken we serializable
[System.Serializable]

public class wave
{
    //we geven hier in het aantal in een array zodat meer dan een kunnen maken
    // een tijd voor dat de volgende enemy mag spawnen
    // een tijd voordat de volgende wave mag spawnen

    // een int om te tellen hoeveel enemie nog over zijn deze willen we niet in inspector ma willen we well later in eenandere class oproepen
    public Groups[] groups;
    public float timeToNextEnemey;
    public float timeToNectWave;

    

}

public class Groups
{
    public Enemy[] enemies;

    [HideInInspector] public int enemiesleft;

}
