using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    Player player;
    [SerializeField] private List<PowerUp> PowerUpList;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }
    public PowerUps GetRandomPowerup()
    {
        if (PowerUpList.Count == 0) return null;
        int _randomIndex = Random.Range(0, PowerUpList.Count);
        return PowerUpList[_randomIndex].upgrade;

    }
}
