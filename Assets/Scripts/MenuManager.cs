using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioManager audioManager;
    public TextMeshProUGUI countdownText;
    public GameObject calibratePanel;
    private GravityController gravityController;

    private int countdownValue = 5;
    private bool isCountingDown = false;

    // Update is called once per frame
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gravityController = new GravityController();
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void CalibrateBtn()
    {
        if (!isCountingDown)
        {
            StartCoroutine(StartCalibration());
        }

    }


    public void QuitBtn()
    {
        Application.Quit();
    }

    private IEnumerator StartCalibration()
    {
        countdownText.gameObject.SetActive(true);
        isCountingDown=true;


        while (countdownValue >0)
            {
                countdownText.text = countdownValue.ToString();
                yield return new WaitForSeconds(1f);
                calibratePanel.gameObject.SetActive(true);
                countdownValue--;
            }
        countdownText.gameObject.SetActive(false);
        calibratePanel.gameObject.SetActive(false);
        gravityController.CalibrateGravity();
        countdownValue = 5;
        isCountingDown = false;



        Debug.Log("Complete");
        }
}


