using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUps powerUps;

    PowerUps.DifferentPowerUps differentPowers;    

    Player player;

    private void Update()
    {
        switch(differentPowers)
        {
            case PowerUps.DifferentPowerUps.healthBoost:
                HealthBoost(powerUps.healthBoost);
                break;
            case PowerUps.DifferentPowerUps.damageBoost:
                DamageBoost(powerUps.damageBoost);
                break;
            case PowerUps.DifferentPowerUps.regen:
                StartCoroutine(HealthRegen());
                break;
        }
    }


    public void HealthBoost(int Value)
    {
      
    }

    public void DamageBoost(int value)
    {
        
    }

    IEnumerator HealthRegen()
    {


        yield return new WaitForSeconds(powerUps.regenRate);
    }
}
