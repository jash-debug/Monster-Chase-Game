using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinManager coinManager;

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
        Debug.Log("CoinManager found: " + (coinManager != null));
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter called");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Coin collided with Player");
            coinManager.CollectCoin(gameObject);
        }
    }
}
