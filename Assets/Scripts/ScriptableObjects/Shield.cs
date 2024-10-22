using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "PowerUpsForPlayer/Shield")]
public class Shield : PowerUps
{
    public float shieldTime;
    public override void AddToYourList(PowerUps shield)
    {
        player.GetComponent<Player>().powerUp.Add(shield);

    }

    public override void Aply(GameObject player)
    {
        player.GetComponent<Player>().shieldDuration += shieldTime;
    }
}
