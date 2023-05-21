using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public int countdownTime;
    public GameObject gameStartPanel;
    public TextMeshProUGUI countdownText;
    public AudioManager audioManager;
    bool isPaused;

    // Update is called once per frame
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        StartCoroutine(CountdownToStart());
    }

    public void PauseGame()
    {
        FindObjectOfType<AudioManager>().PlaySound("TapButton");
        isPaused = !isPaused;

        if (isPaused)
        {
            FindObjectOfType<AudioManager>().PlaySound("TapButton");
            Input.gyro.enabled = true;
            pausePanel.SetActive(false);
            FindObjectOfType<AudioManager>().ResumeAllSound();
        }
        else
        {
            FindObjectOfType<AudioManager>().PlaySound("TapButton");
            Input.gyro.enabled = false;
            pausePanel.SetActive(true);
            FindObjectOfType<AudioManager>().PauseAllSound();
        }
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().PlaySound("TapButton");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }



    public void BackMenu()
    {
        FindObjectOfType<AudioManager>().PlaySound("TapButton");
        SceneManager.LoadScene(0);
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        FindObjectOfType<AudioManager>().PlaySound("GameStart");
        Input.gyro.enabled = true;
        countdownText.text = "GO!";
        yield return new WaitForSeconds(1f);



        gameStartPanel.gameObject.SetActive(false);
    }

    public bool isPausedRunning()
    {
        return isPaused;
    }

}

