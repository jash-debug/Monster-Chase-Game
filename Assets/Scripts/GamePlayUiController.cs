using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayUiController : MonoBehaviour
{
    // Start is called before the first frame update
   public void Restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }
}
