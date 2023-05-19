using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    [SerializeField] GameObject WinUI;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")){
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            FindObjectOfType<AudioManager>().PlaySound("WinState");
            WinUI.SetActive(true);
            Input.gyro.enabled = false;

        }
    }
}
