using UnityEngine.SceneManagement;
using UnityEngine;

public class CustomSceneManager: MonoBehaviour
{
    private static bool selected = false;
    public static void ChangeScene(string newScene)
    {
        GameVariables.SceneName_Last = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(newScene);
        GameVariables.SceneName_Current = newScene;
        
    }
    public static void Quit()
    {
        Application.Quit();
    }

    public static void ChangeSelect()
    {
        selected = !selected;
    }
}