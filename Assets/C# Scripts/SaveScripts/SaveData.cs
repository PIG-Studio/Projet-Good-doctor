using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
                if (valid) { GameVariables.SaveName = input; }
                else { GameVariables.SaveName = ""; }
        
                Debug.Log("GameVariables.SaveName = " + GameVariables.SaveName + " (FROM : GameVariables, apres modif de la valeur");
        
                return valid; 
        }
        
        /// <summary>
        /// create a dictionary with values needed to save a game, and passes it to SaveLoadMethods.WriteSaveGame
        /// </summary>
        /// <returns>void</returns>
        public static void SaveGame()
        {
                Dictionary<string, string> input = new Dictionary<string, string>();
                input["DeskName"] = DesksConvert.DeskToString(GameVariables.DeskName);
                input["SaveName"] = GameVariables.SaveName;
                input["SceneName"] = GameVariables.SceneName_Current;
                string pos = GameVariables.LatestPos.Item1.ToString() + " , " +
                             GameVariables.LatestPos.Item2.ToString();
                input["Position"] = pos;
                SaveLoadMethods.WriteSaveGame(input);
        }
        
    
}

