using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    //maken een variable voor het punt van schieten en het object
    public Transform attackPoint;

    public GameObject projectile;

    //op de schiet functie die geregld is in unity
    private void OnShooting(InputAction.CallbackContext context)
    {
        //als de actie is gedaan dan maken we het object aan op het aanval punt en kijkt na hoe het aanval punt kijkt
        if (context.performed)
        {
            Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
        
    }
}
