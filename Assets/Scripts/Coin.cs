using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinManager coinManager;

    void Start()
    {
        coinManager = FindObjectOfType<CoinManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinManager.CollectCoin(gameObject);
        }
    }
}
