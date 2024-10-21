using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Advertisements.Utilities;

//Data

//maak een tussen script
//maak prefabs

public abstract class PowerUps : ScriptableObject
{
    protected Player player;
    //public enum DifferentPowerUps { regen, healthBoost,damageBoost, shield, ricachetbullet, charginglaser,blackholebullet}
    public abstract void AddToYourList(PowerUps player);

    public abstract void Aply(GameObject player);

}
