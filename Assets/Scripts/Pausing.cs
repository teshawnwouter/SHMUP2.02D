using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{
    [SerializeField]private GameObject pauseMenu;
    private bool isPaused = false;

    [SerializeField] private Shooting shooting;
   
    public void OnPause()
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
  
    void Update()
    {
        
    }
}
