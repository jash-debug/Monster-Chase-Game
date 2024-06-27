using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public CharacterSelectionManager CharacterDb;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    void Start()
    {
        if (CharacterDb == null)
        {
            Debug.LogError("CharacterDb is not assigned.");
            return;
        }

        if (artworkSprite == null)
        {
            Debug.LogError("artworkSprite is not assigned.");
            return;
        }

        if (PlayerPrefs.HasKey("selectedOption"))
        {
            Load();
            Debug.Log("Load called: selectedOption = " + selectedOption);
        }
        else
        {
            selectedOption = 0;
            Debug.Log("No PlayerPrefs key found for selectedOption. Defaulting to 0.");
        }
        UpdateCharacter(selectedOption);
    }

    public void NextCharacter()
    {
        if (CharacterDb == null)
        {
            Debug.LogError("CharacterDb is not assigned.");
            return;
        }

        selectedOption++;
        if (selectedOption >= CharacterDb.CharacterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void PreviousCharacter()
    {
        if (CharacterDb == null)
        {
            Debug.LogError("CharacterDb is not assigned.");
            return;
        }

        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = CharacterDb.CharacterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        if (CharacterDb == null)
        {
            Debug.LogError("CharacterDb is not assigned.");
            return;
        }

        Character character = CharacterDb.GetCharacter(selectedOption);
        if (character != null)
        {
            artworkSprite.sprite = character.characterImage;
            Debug.Log("Character updated: " + character.characterImage.name);
        }
        else
        {
            Debug.LogError("Character not found for selectedOption: " + selectedOption);
        }
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
        Debug.Log("Loaded selectedOption from PlayerPrefs: " + selectedOption);
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
        Debug.Log("Saved selectedOption to PlayerPrefs: " + selectedOption);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("MonsterChase");
    }
}
