using System.Collections.Generic;
using GameCore.GameVAR;
using SaveScripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using static GameCore.GameVAR.Variables;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    
        public string sceneName = SceneManager.GetActiveScene().name ;
        //ublic float playerHealth;
        //public int playerScore;
        //public (float,float) position;
        
        /// <summary>
        /// met GameVariables.SaveName a 'input' si le nom est valide
        /// </summary>
        /// <param name="input">new save name, validity will be tested</param>
        /// <returns>bool => input's validity to be the new SaveName, checked using SaveLoadMethods.ValidNameToSave</returns>
        public static bool SetSaveName(string input)
        {
        
                bool valid = SaveLoadMethods.ValidNameToSave(input);// TODO : && nom pas en doublon 
                if (valid) { SaveName = input; }
                else { SaveName = ""; }
        
                Debug.Log("GameVariables.SaveName = " + SaveName + " (FROM : GameVariables, apres modif de la valeur");
        
                return valid; 
        }
        
        /// <summary>
        /// create a dictionary with values needed to save a game, and passes it to SaveLoadMethods.WriteSaveGame
        /// </summary>
        /// <returns>void</returns>
        public static void SaveGame()
        {
                Dictionary<string, string> input = new Dictionary<string, string>();
                input["DeskName"] = Variables.Desk.SceneName;
                input["SaveName"] = SaveName;
                input["SceneName"] = SceneNameCurrent;
                string pos = LatestPos.Item1 + " , " + LatestPos.Item2;
                input["Position"] = pos;
                SaveLoadMethods.WriteSaveGame(input);
        }
        
    
}

