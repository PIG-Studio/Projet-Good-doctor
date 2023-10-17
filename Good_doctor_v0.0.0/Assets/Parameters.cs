using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parameters : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Parmeters";
    public void Change_Scene_To_Parmeters()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
