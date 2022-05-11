using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInteraction : MonoBehaviour
{
    public void PlayGame()
    {
        SceneBehavior.ExitMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
