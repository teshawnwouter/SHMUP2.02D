using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform attackPoint;

    public GameObject projectile;

    private void OnShooting(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(projectile, attackPoint.position, Quaternion.identity);
        }
        
    }
}
