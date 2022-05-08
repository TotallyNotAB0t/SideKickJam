using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehavior : MonoBehaviour
{
    public static void GoToScene(string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
