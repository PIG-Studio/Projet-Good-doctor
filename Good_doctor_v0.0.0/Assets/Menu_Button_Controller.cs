using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button_Controller : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level 1";
    public void Level1Button()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
