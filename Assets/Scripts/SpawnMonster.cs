using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    public GameObject[] monsters;
    public Transform leftPos, RightPos;

    private int animalIndex;
    private float animalPos;

    private GameObject spawnedMonster;


    // Start is called before the first frame update
    void Start()
    {
        
            StartCoroutine(SpawnMonsters());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
        
            animalIndex = Random.Range(0, monsters.Length);

            animalPos = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsters[animalIndex]);

            if (animalPos == 0)
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(5, 10);
            }
            else
            {
                spawnedMonster.transform.position = RightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(5, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

        }
    }
}
