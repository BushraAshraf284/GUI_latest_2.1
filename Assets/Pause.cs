using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject questionSection;

    public void PauseGame()
    {
        
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        questionSection.SetActive(false);

    }

    public void ResumeGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(false);
        questionSection.SetActive(true);
    }

    
}
