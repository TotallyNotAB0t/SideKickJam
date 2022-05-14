using UnityEngine;

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

    public void BackToMenu()
    {
        SceneBehavior.GoToScene("MainMenu");
    }
}
