using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static string DeskName { get; private set; }
    public static string SaveName { get; private set; }
    
    public static (int, int) LatestPos { get; private set; }
    
    public static string SceneName_Current { get; set; }
    public static string SceneName_Last { get; set; }
    
    private const string DeskDepart = "DESK_Base";
    
    public void SetVariables(string nom, string desk = DeskDepart )
    {
        DeskName = desk;
        SaveName = nom;
    }
    
    
    private void LoadGameVariablesFromFile(string saveName)
    {
        Dictionary<string, string> saveData = SaveLoadMethods.ParseData(saveName);
        if (saveData != null)
        {
            SetVariables(saveData["DeskName"]);
            SetVariables(saveData["SaveName"]);
            SetVariables(saveData["SceneName"]);
            CustomSceneManager.ChangeScene(SceneName_Current);
            Debug.Log("Save data loaded");
        }
        else
        {
            Debug.Log("Save corrupted");
        }
    }


    public void SaveGame()
    {
        Dictionary<string, string> input = new Dictionary<string, string>();
        input["DeskName"] = DeskName;
        input["SaveName"] = SaveName;
        input["SceneName"] = SceneName_Current;

        SaveLoadMethods.WriteSaveGame(input);
    }

    public void NewGame(string gameName)//difficulty ? si oui ajouter en param et property
    {
        if (SaveLoadMethods.ValidNameToSave(gameName))
        {
            SetVariables(gameName);
            UnityEngine.SceneManagement.SceneManager.LoadScene(DeskDepart);
        }
    }



    
    
    
}
