using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI labelText;
    public Rigidbody ball;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ball.isKinematic = true;
            FindObjectOfType<AudioManager>().StopSound("MainTheme");
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
            gameOverPanel.SetActive(true);
            labelText.text = "Oh no! You're falling! ";
        }

    }
}
