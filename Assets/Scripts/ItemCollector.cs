using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    int keys = 0;
    [SerializeField] TextMeshProUGUI keyText;
    [SerializeField] TextMeshProUGUI coinText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinText.text = "" + coins;
            FindObjectOfType<AudioManager>().PlaySound("CoinsPick");
        }


        if (other.gameObject.CompareTag("Key"))
        {
            Destroy (other.gameObject);
            keys++;
            keyText.text = "Key :" + keys;
            FindObjectOfType<AudioManager>().PlaySound("CoinsPick");
        }
    }

    public int GetKeyCount()
    {
        return keys;
    }
}
