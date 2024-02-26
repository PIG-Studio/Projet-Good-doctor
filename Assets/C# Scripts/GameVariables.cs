using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Alteruna;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static Desks DeskName { get; private set; }

    private static Desks _startingDesk = Desks.BaseDesk;
    public static string SaveName { get;  set; }

    public static (int, int) LatestPos { get; private set; }

    public static string SceneName_Current { get; set; }
    public static string SceneName_Last { get; set; }



    /// <summary>
    /// initialize GameVariables' values to default, unless values are specified
    /// </summary>
    /// <param name="saveName">new save name, validity have to tested beforehand</param>
    /// <param name="deskName">defaults to starting desk</param>
    /// <param name="multiRoom">defaults to null</param>
    /// <returns> void</returns>
    public static void SetVariables(string saveName, Desks deskName = Desks.BaseDesk)
    {
        DeskName = deskName;
        SaveName = saveName;
    }


    /// <summary>
    /// initialise les valeurs de GameVariables aux valeurs d'un fichier de sauvegarde
    /// </summary>
    /// <param name="saveName">save name to find</param>
    /// <returns>void</returns>
    private void LoadGameVariablesFromFile(string saveName)
    {
        Dictionary<string, string> saveData = SaveLoadMethods.ParseData(saveName);
        if (saveData != null) // TODO : check if save data is valid
        {
            DeskName = DesksConvert.ToDesk(saveData["DeskName"]);
            SetVariables(saveData["SaveName"]);
            SetVariables(saveData["SceneName"]);
            CustomSceneManager.ChangeScene(SceneName_Current);
            Debug.Log("Save data loaded");
        }
        else
        {
            Debug.Log("Save corrupted / non-existing");
        }
    }





    /// <summary>
    /// Makes necessary calls to create and start a new game
    /// </summary>
    /// <param name="gameName">new save name, validity will be tested</param>
    /// <returns> void, as if the new game's save isn't valid, nothing happens, else this function handle the calls needed to start a game</returns>
    public static void NewGame(string gameName) //difficulty ? si oui ajouter en param et property
    {
        if (SaveLoadMethods.ValidNameToSave(gameName))
        {
            SetVariables(gameName);//, roomMenu:new GameObject("RoomMenu").AddComponent<RoomMenu>());
            SaveData.SaveGame();
            UnityEngine.SceneManagement.SceneManager.LoadScene(DesksConvert.ToString(_startingDesk));
        }
    }
    

    



}
