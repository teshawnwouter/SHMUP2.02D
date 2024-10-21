using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Upgrades", menuName = "PowerUpsForPlayer/HealthBoost")]
public class HealthBoost : PowerUps
{

    public int value;
    public override void AddToYourList(PowerUps healthBoost)
    {
        player.GetComponent<Player>().powerUp.Add(healthBoost);
    }

    public override void Aply(GameObject player)
    {
        player.GetComponent<Player>().healthpoints += value;
    }
}
