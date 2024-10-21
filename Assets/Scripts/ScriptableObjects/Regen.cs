using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "Upgrades", menuName = "PowerUpsForPlayer/regen")]
public class Regen : PowerUps
{
    //reffrence the player list

    public int regenRateValue;
    public override void AddToYourList(PowerUps regenbuff)
    {
        player.GetComponent<Player>().powerUp.Add(regenbuff);
    }

    public override void Aply(GameObject player)
    {
        player.GetComponent<Player>().maxRegenTime = regenRateValue;
    }


}
