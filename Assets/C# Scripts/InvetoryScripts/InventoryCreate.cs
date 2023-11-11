using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryData 
{
    public string sceneName = SceneManager.GetActiveScene().name;

    public string GetSceneName()
    {
        return sceneName;
    }
}
