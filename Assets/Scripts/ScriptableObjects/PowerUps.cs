using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements.Utilities;

//Data

//maak een tussen script
//maak prefabs

[CreateAssetMenu(fileName = "Upgrades" , menuName ="PowerUpsForPlayer")]
public class PowerUps : ScriptableObject
{
   public enum DifferentPowerUps { regen, healthBoost,damageBoost}

    public DifferentPowerUps differentPowerUps;

    public  int healthBoost;

    public int damageBoost;

    public int regenRate;

    public bool canBeShielded;
    public int shieldDuration;

   
    

    
}
