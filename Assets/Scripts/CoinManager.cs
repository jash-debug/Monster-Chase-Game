using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Text coinText;
    public int coinCount = 0;
    public GameObject[] coinPrefabs; // Array of different coin prefabs
    public float spawnInterval = 1f; // Interval between spawns
    public int maxCoins = 10; // Maximum number of coins at a time
    public float coinLifetime = 10f; // Time before coins disappear
    public float xRange = 126f; // Range for x-axis spawn positions
    private List<GameObject> coins = new List<GameObject>(); // List to keep track of spawned coins

    // Start is called before the first frame update
    void Start()
    {
        // Initial coin at the center
        SpawnCoin(Vector3.zero);
        StartCoroutine(SpawnCoins());
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();

        foreach (GameObject coin in coins)
        {
            if (coin != null)
            {
                coin.transform.position += Vector3.up * Mathf.Sin(Time.time) * 0.1f;
            }
        }
    }

    IEnumerator SpawnCoins()
    {
        while (true)
        {
            if (coins.Count < maxCoins)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-xRange, xRange), 0, 0);
                SpawnCoin(spawnPosition);
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnCoin(Vector3 position)
    {
        int coinIndex = Random.Range(0, coinPrefabs.Length);
        GameObject coin = Instantiate(coinPrefabs[coinIndex], position, Quaternion.identity);
        coins.Add(coin);
        StartCoroutine(RemoveCoinAfterTime(coin, coinLifetime));
    }

    IEnumerator RemoveCoinAfterTime(GameObject coin, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (coin != null)
        {
            coins.Remove(coin);
            Destroy(coin);
        }
    }

    public void CollectCoin(GameObject coin)
    {
        coinCount++;
        coins.Remove(coin);
        Destroy(coin);
    }
}
