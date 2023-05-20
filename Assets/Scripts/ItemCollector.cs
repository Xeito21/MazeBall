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
            FindObjectOfType<AudioManager>().PlaySound("KeyPickUp");
        }
    }


    private void SaveCollectibleData()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.Save();
    }

    private void LoadCollectibleData()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        coinText.text = "" + coins;
    }

    private void OnEnable()
    {
        LoadCollectibleData();
    }

    private void OnDisable()
    {
        SaveCollectibleData();
    }

    public int GetKeyCount()
    {
        return keys;
    }
}
