using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1_Button_Controller : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Menu";
    public void BackToMenuButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
