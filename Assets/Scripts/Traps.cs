using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Traps : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject gameOverPanel;
    private Vector3 originalScale;
    private Vector3 scaleTo;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            gameOverPanel.SetActive(true);
            originalScale = playerTransform.localScale;
            scaleTo = new Vector3(originalScale.x, -0.003f, -0.003f);

            Input.gyro.enabled = false;

            playerTransform.DOScale(scaleTo, 0.5f).SetEase(Ease.InOutSine);
        }
        
    }


}
