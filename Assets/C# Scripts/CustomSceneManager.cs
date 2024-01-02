using UnityEngine.SceneManagement;
using UnityEngine;

public class CustomSceneManager: MonoBehaviour
{
    public static void ChangeScene(string newScene)
    {
        GameVariables.SceneName_Last = SceneManager.GetActiveScene().name;
        if (newScene == "Desk")
        {
            newScene = GameVariables.DeskName;

        }
        SceneManager.LoadScene(newScene);
        GameVariables.SceneName_Current = newScene;
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
