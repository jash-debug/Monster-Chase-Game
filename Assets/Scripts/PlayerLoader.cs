using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public CharacterPrefabDatabase characterPrefabDb;

    void Start()
    {
        int selectedOption = PlayerPrefs.GetInt("selectedOption", 0);
        GameObject selectedCharacterPrefab = characterPrefabDb.GetCharacterPrefab(selectedOption);
        
        if (selectedCharacterPrefab != null)
        {
            Instantiate(selectedCharacterPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Selected character prefab is null. Index: " + selectedOption);
        }
    }
}
