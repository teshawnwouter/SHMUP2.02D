using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform attackPoint;

    public GameObject projectile;


    private void Start()
    {
        
    }
    public void OnShooting(InputValue value)
    {
        Instantiate(projectile,attackPoint.position,Quaternion.identity);
    }

    void Update()
    {
        
    }
}
