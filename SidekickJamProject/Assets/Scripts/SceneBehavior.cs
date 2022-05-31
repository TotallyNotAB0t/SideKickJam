using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    public static void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public static void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void ExitMenu()
    {
        SceneManager.LoadScene("MapScene");
    }
}
