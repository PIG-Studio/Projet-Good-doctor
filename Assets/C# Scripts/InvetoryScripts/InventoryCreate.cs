using UnityEngine.SceneManagement;

public class InventoryData 
{
    public string SceneName = SceneManager.GetActiveScene().name;

    public string GetSceneName()
    {
        return SceneName;
    }
}
