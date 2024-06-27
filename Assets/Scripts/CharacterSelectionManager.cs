using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CharacterSelectionManager", menuName = "Character/CharacterSelectionManager")]
public class CharacterSelectionManager : ScriptableObject
{
    public Character[] characters; // Array of character scriptable objects

    public int CharacterCount
    {
        get
        {
            return characters.Length;
        }
    }

    public Character GetCharacter(int index)
    {
        if (index >= 0 && index < characters.Length)
        {
            return characters[index];
        }
        return null;
    }
}
