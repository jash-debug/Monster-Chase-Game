using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Canvas howToPlayCanvas;

    public void Playgame()
    {
        int selected = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selected;
        
        SceneManager.LoadScene("MonsterChase");
    }

    public void HowToPlay()
    {
        howToPlayCanvas.enabled = true;
    }

    public void MainMenu()
    {
        howToPlayCanvas.enabled = false;
    }

}
