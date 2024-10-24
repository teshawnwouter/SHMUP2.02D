using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TimeSLow : MonoBehaviour
{
  PlayerControler playerControler;

    public GameObject indicator;

    [SerializeField]private bool isInSlowMode = false;
    [SerializeField] private bool isOnCooldown = false;
    [SerializeField]private float slowTime = 5f;
    [SerializeField]private float slowEffect = .3f;
    [SerializeField] private float slowCooldown = 3f;

    private void Awake()
    {
        playerControler = new PlayerControler();

        playerControler.PCInputmanager.Enable();
        playerControler.PCInputmanager.TimeSlow.performed += TimeSlow_performed;
    }

    private void TimeSlow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (!isOnCooldown)
        {
            isInSlowMode = true;
        }
        
    }

    void Start()
    {
        slowTime = 5f;
        slowEffect = .3f;
        isInSlowMode = false;
        isOnCooldown = false;
        slowCooldown = 3f;
    }

    void Update()
    {
        if (isInSlowMode && !isOnCooldown)
        {
            indicator.SetActive(true);
            slowTime -= Time.unscaledDeltaTime;
            Time.timeScale = slowEffect;
        }

        if (slowTime <= 0 && !isOnCooldown)
        {
            indicator.SetActive(false);
            Time.timeScale = 1f;
            isInSlowMode = false;
            slowTime = 5f;
            isOnCooldown = true;
           
        }

        if(isOnCooldown)
        {
            slowCooldown -= Time.unscaledDeltaTime;
        }
        if(slowCooldown <= 0)
        {
            slowCooldown = 3f;
            isOnCooldown = false;
        }
    }
}
