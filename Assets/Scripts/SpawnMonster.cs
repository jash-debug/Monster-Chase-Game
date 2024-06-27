using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject[] monsters;

    private int animalIndex;


    private GameObject spawnedMonster;

    void Start()
    {
        // Check if monsters, leftPos, and rightPos are assigned
        if (monsters == null || monsters.Length == 0)
        {
            Debug.LogError("Monsters array is not assigned or empty.");
            return;
        }

        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            animalIndex = Random.Range(0, monsters.Length);
            //animalPos = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsters[animalIndex]);
            Debug.Log("Spawned Monster: " + spawnedMonster.name);
            spawnedMonster.transform.position = new Vector2(Random.Range(-126, 126), 54);

            if (spawnedMonster.transform.position.x < 0)
            {
                
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(5, 10);
                Debug.Log("Monster spawned at left position with speed: " + spawnedMonster.GetComponent<Enemy>().speed);
            }
            else
            {
               
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(5, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                Debug.Log("Monster spawned at right position with speed: " + spawnedMonster.GetComponent<Enemy>().speed);
            }
        }
    }
}
