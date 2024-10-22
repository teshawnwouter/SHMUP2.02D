using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Pausing : MonoBehaviour
{
    //maken links aan het object  dan  aan en uit gezet word een bool om te kijken of je gepauseerd heb een link aan schiet sccipt en het de controlls
    [SerializeField]private GameObject pauseMenu;
    private bool isPaused = false;

    [SerializeField] private Shooting shooting;

    PlayerControler playerControler;


    private void Awake()
    {
        //liknen het schiet scritp en maken een new versie van de controlls aan
        shooting = GetComponent<Shooting>();
        playerControler = new PlayerControler();

       //we maken een event die allen kijk of de actie is gedaan en zetten deze aan
        playerControler.PCInputmanager.Pause.performed += Pause_performed;
        playerControler.PCInputmanager.Pause.Enable();
    }

    //maken de functie die de bool verandert naar true of false
    private void Pause_performed(InputAction.CallbackContext context)
    {
        if (isPaused)
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

    //hier zetten we  het object aan het schiet script op false en het tijd van de werld op 0
    void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        shooting.enabled = false;

    }

    // hier zetten we het pause scherm uit het schiet aan en het tijd weer normaal
    public void UnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
       shooting.enabled = true;
    }
}
