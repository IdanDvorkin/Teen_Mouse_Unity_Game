using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public AudioSource audioSource; // Add this to reference your audio source

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                resumeGame();
            else
                pauseGame();
        }
    }

    public void pauseGame()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        audioSource.Pause(); // Pauses the audio
    }

    public void resumeGame()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        audioSource.UnPause(); // Resumes the audio
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
