using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioManager audioManager;
    bool isPaused;

    // Update is called once per frame
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            FindObjectOfType<AudioManager>().PlaySound("TapButton");
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            FindObjectOfType<AudioManager>().ResumeAllSound();
        }
        else
        {
            FindObjectOfType<AudioManager>().PlaySound("TapButton");
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            FindObjectOfType<AudioManager>().PauseAllSound();
        }
    }



    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public bool isPausedRunning()
    {
        return isPaused;
    }

}

