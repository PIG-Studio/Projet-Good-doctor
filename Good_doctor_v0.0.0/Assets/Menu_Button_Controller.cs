using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button_Controller : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level 1";
    public void Change_Scene_to_Level1_Button()
    {
        SceneManager.LoadScene(newGameLevel);
    }
    
    [SerializeField] private string parameters = "Parameters";
    public void Change_Scene_to_Parameters_Button()
    {
        SceneManager.LoadScene(parameters);
    }
    public void ShutDown()
    {
        Application.Quit();
    }
}
