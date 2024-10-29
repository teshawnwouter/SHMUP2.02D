using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class TimeSLow : MonoBehaviour
{
    private enum State { normal,inTimeSlow,cantTimeSlow}

    [SerializeField] State state;

  PlayerControler playerControler;

    public GameObject indicator;
    [SerializeField] private Image timeSlowCooldownUI;




    [SerializeField] private float slowTime;
    private float maxSlowTime = 5f;

    [SerializeField] private float slowEffect = .3f;
    [SerializeField] private float slowCooldown;
     private float maxSlowCooldown = 5f;


    private void Awake()
    {
        playerControler = new PlayerControler();

        playerControler.PCInputmanager.Enable();
        playerControler.PCInputmanager.TimeSlow.performed += TimeSlow_performed;
    }

    private void TimeSlow_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (state == State.normal)
        {
            StartTimeSlow();
        }

        
    }

    void Start()
    {
        slowTime = maxSlowTime;

        timeSlowCooldownUI.fillAmount = 0f;
        slowCooldown = maxSlowCooldown;
        
        state = State.normal;

        slowEffect = .3f;
    }

    void Update()
    {
        if (state == State.inTimeSlow)
        {
            indicator.SetActive(true);
            slowTime -= Time.unscaledDeltaTime;
            Time.timeScale = slowEffect;
            timeSlowCooldownUI.fillAmount = 1;
        }
        else
        {
            indicator.SetActive(false);
        }



        TimeSlowCooldown();
    }

    private void StartTimeSlow()
    {
        if (state == State.normal)
        {
            state = State.inTimeSlow;
        }
    }

    private void TimeSlowCooldown()
    {
       

        if (slowTime <= 0)
        {
            state = State.cantTimeSlow;
        }

        if(state == State.cantTimeSlow)
        {
            timeSlowCooldownUI.fillAmount -= 1 / slowCooldown * Time.unscaledDeltaTime;
        }

        if (timeSlowCooldownUI.fillAmount <= 0)
        {
            timeSlowCooldownUI.fillAmount = 0f;
            slowCooldown = maxSlowCooldown;
            slowTime = maxSlowTime;
            state = State.normal;
        }

    }

}
