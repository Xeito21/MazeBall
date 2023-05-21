using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Traps : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject gameOverPanel;
    public TextMeshProUGUI labelText;
    public MonoBehaviour scriptDisable;
    private Vector3 originalScale;
    private Vector3 scaleTo;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            gameOverPanel.SetActive(true);
            labelText.text = "Please avoid sharp objects...";
            originalScale = playerTransform.localScale;
            scaleTo = new Vector3(originalScale.x, -0.003f, -0.003f);
            scriptDisable.enabled = false;
            Input.gyro.enabled = false;

            playerTransform.DOScale(scaleTo, 0.5f).SetEase(Ease.InOutSine);
        }
        
    }


}
