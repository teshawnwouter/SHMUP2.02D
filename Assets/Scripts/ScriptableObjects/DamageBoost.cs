using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrades", menuName = "PowerUpsForPlayer/weaponUpgrade")]

public class DamageBoost : PowerUps
{

    public int weaponUpgrade;
    public override void AddToYourList(PowerUps weaponUpgrade)
    {
        player.GetComponent<Player>().powerUp.Add(weaponUpgrade);
    }

    public override void Aply(GameObject player)
    {
        player.GetComponent<Player>().weaponBoost += weaponUpgrade;
    }
}
