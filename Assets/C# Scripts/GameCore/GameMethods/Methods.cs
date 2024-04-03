using System.Collections.Generic;
using CustomScenes;
using UnityEngine;
using static GameCore.Constantes;
using static GameCore.Variables;
using static CustomScenes.Manager;

namespace GameCore
{

    public static class Methods
    {
        /// <summary>
        /// initialize GameVariables' values to default, unless values are specified
        /// </summary>
        /// <param name="saveName">new save name, validity have to tested beforehand</param>
        /// <param name="deskName">defaults to starting desk</param>
        /// <returns> void</returns>
        public static void SetVariables(string saveName, Desk deskName = null)
        {
            Variables.Desk = deskName ?? StartingDesk;
            SaveName = saveName;
            LoadName = null;
        }

        /// <summary>
        /// Fait les appels necessaires pour lancer une partie
        /// </summary>
        /// <param name="gameName">nom de la partie, validite testee</param>
        /// <returns> void, si le nom est invalide => rien ne se passe, sinon => appels necessaires pour lancer game</returns>
        public static void NewGame(string gameName) //difficulty ? si oui ajouter en param et property
        {
            if (SaveLoadMethods.ValidNameToSave(gameName))
            {
                SetVariables(gameName);
                SaveData.SaveGame();
                ChangeScene(StartingDesk.SceneName);
            }
        }

        /// <summary>
        /// initialise les valeurs de GameVariables aux valeurs d'un fichier de sauvegarde
        /// </summary>
        /// <param name="saveName">nom de la sauvegarde a charger</param>
        /// <returns>void</returns>
        private static void LoadGameVariablesFromFile(string saveName)
        {
            Dictionary<string, string> saveData = SaveLoadMethods.ParseData(saveName);
            if (saveData != null) // TODO : check if save data is valid
            {
                Variables.Desk = saveData["DeskName"].ToDesk();
                SetVariables(saveData["SaveName"]);
                SetVariables(saveData["SceneName"]);
                ChangeScene(SceneName_Current);
                Debug.Log("Save data loaded");
            }
            else
            {
                Debug.Log("Save corrupted / non-existing");
            }
        }
    }
}