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
}
