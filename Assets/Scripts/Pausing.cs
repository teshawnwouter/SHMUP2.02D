using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{
    private GameObject pauseMenu;


    public void OnPause(InputValue value)
    {
        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
    }

    void Start()
    {

        pauseMenu = GetComponent<GameObject>();
    }
    public void UnPause()
    {
        pauseMenu.SetActive(false);
    }
  
    void Update()
    {
        
    }
}
