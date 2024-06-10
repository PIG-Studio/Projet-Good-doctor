using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameCore.Variables;

namespace SaveScripts
{
        public class SaveData : MonoBehaviour
        {

                public string sceneName = SceneManager.GetActiveScene().name;
                //public float playerHealth;
                //public int playerScore;
                //public (float,float) position;

                /// <summary>
                /// met GameVariables.SaveName a 'input' si le nom est valide
                /// </summary>
                /// <param name="input">new save name, validity will be tested</param>
                /// <returns>bool => input's validity to be the new SaveName, checked using SaveLoadMethods.ValidNameToSave</returns>
                public static bool SetSaveName(string input)
                {

                        bool valid = SaveLoadMethods.ValidNameToSave(input); // TODO : && nom pas en doublon 
                        Variable.SaveName = valid ? input : "";

                        Debug.Log("GameVariables.SaveName = " + Variable.SaveName +
                                  " (FROM : GameVariables, apres modif de la valeur");

                        return valid;
                }

                /// <summary>
                /// create a dictionary with values needed to save a game, and passes it to SaveLoadMethods.WriteSaveGame
                /// </summary>
                /// <returns>void</returns>
                public static void SaveGame()
                {
                        Dictionary<string, string> input = new Dictionary<string, string>();
                        input["DeskName"] = Variable.Desk.SceneName;
                        input["SaveName"] = Variable.SaveName;
                        input["SceneName"] = Variable.SceneNameCurrent;
                        string pos = Variable.LatestPos.Item1 + " , " + Variable.LatestPos.Item2;
                        input["Position"] = pos;
                        SaveLoadMethods.WriteSaveGame(input);
                }
        }
}