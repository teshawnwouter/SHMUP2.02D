using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pausing : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;
    private bool isPaused = false;

    [SerializeField] private Shooting shooting;

    PlayerControler playerControler;

    private bool IsPaused;

    private void Awake()
    {
        shooting = GetComponent<Shooting>();
        playerControler =  new PlayerControler();

       
        playerControler.PCInputmanager.Pause.performed += Pause_performed;
        playerControler.PCInputmanager.Pause.Enable();
    }

    private void Pause_performed(InputAction.CallbackContext context)
    {
        if (IsPaused)
        {
            isPaused = false;
            UnPause();
        }
        else
        {
            isPaused = true;
            Pause();
        }
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        shooting.enabled = false;

    }
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
       shooting.enabled = true;
    }
}
