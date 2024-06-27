using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterPrefabDatabase", menuName = "Character/CharacterPrefabDatabase")]
public class CharacterPrefabDatabase : ScriptableObject
{
    public GameObject[] characterPrefabs; // Array of character prefabs

    public GameObject GetCharacterPrefab(int index)
    {
        if (index >= 0 && index < characterPrefabs.Length)
        {
            return characterPrefabs[index];
        }
        return null;
    }

    public int CharacterCount
    {
        get
        {
            return characterPrefabs.Length;
        }
    }
}
