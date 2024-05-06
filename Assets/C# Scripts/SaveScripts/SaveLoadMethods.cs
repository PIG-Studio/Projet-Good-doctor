using System;
using System.Collections.Generic;
using System.IO;
using GameCore.Variables;
using TypeExpand.String;
using Parameters;
using UnityEngine;
using static CustomScenes.Manager;

namespace SaveScripts
{
    public class SaveLoadMethods : MonoBehaviour
    {

        public static bool ValidNameToSave(string testStr)
        {
            bool retour = true;
            if (testStr.Length < 3 || testStr.Length > 15)
                retour = false;
            else
            {
                foreach (var lettre in testStr)
                {
                    if (retour && lettre == '@')
                        retour = false;
                }
            }

            Debug.Log($"Save name valid : {retour} ({testStr}");
            return retour;
        }

        // TODO : creer une fonction verifiant la validite des data au loading, si non, ParseData return null
        public static Dictionary<string, string> ParseData(string saveName)
        {
            string[] sepa = saveName.Split('@');
            StreamReader sr = new StreamReader(Values.SavesPath + '/' + sepa[0] + saveName);
            string line = sr.ReadLine();
            string cle, valeur;
            string[] lineSplitted;
            Dictionary<string, string> retour = new Dictionary<string, string>();

            while (line != null)
            {
                lineSplitted = line.Split(':');
                (cle, valeur) = (lineSplitted[0], lineSplitted[1]); //valeur est un gamevariable
                retour[cle] = valeur;
                if (lineSplitted.Length != 2)
                {
                    return null;
                }

                line = sr.ReadLine();
            }

            sr.Close();
            return retour;
        }

        public static bool CheckData(Dictionary<string, string> parsedData)
        {
            foreach (var miettes in parsedData)
            {
                if (miettes.Key == "SaveName")
                {
                    if (File.Exists(Values.SavesPath + '/' + miettes.Value))
                    {
                        return false;
                    }

                    if (ValidNameToSave(miettes.Value) == false)
                    {
                        return false;
                    }
                }

                if (miettes.Key == "Position")
                {
                    if (miettes.Value.HasNbInString() == false)
                    {
                        return false;
                    }
                }

                if (miettes.Key == "DeskName")
                {
                    if (miettes.Value.IsDesk() == false)
                    {
                        return false;
                    }
                }

                if (miettes.Key == "SceneName")
                {
                    try
                    {
                        ChangeScene(miettes.Value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return false;
                    }
                }
            }

            return true;
        }

        public Dictionary<string, string> ListAvailableSaves_Latest()
        {

            // TODO : lis tout les fichiers d un dossier, si nom, extension et data du fichier sont a un fornat valide, ajouter le fichier la liste
            //
            return new Dictionary<string, string>();

        }

        public Dictionary<string, string> ListAvailableSaves_Detailled()
        {
            // TODO : lis tout les fichiers d un dossier, si nom, extension et data du fichier sont a un fornat valide, ajouter le fichier la liste
            return new Dictionary<string, string>();
        }

        public static void WriteSaveGame(Dictionary<string, string> inputVariables)
        {
            string date = DateTime.Now.ToString("G");
            date = date.Replace(':', '.');
            date = date.Replace('/', '_');
            Debug.Log(date);
            string saveName = Variable.SaveName;
            // TODO : ecrire les variables dans un fichier .json ?
            string fileName = saveName + "@" + date;
            if (Directory.Exists(Values.SavesPath +
                                 '/' + saveName) == false)
            {
                Directory.CreateDirectory(Values.SavesPath
                                          + '/' + saveName);
                File.Create(Values.SavesPath + '/' +
                            saveName + '/' + fileName + ".save").Close();
            }
            else
            {
                File.Create(Values.SavesPath + '/' +
                            saveName + '/' + fileName + ".save").Close();
            }

            StreamWriter sw = new StreamWriter(Values.SavesPath + '/' + saveName + '/' + fileName + ".save");
            foreach (var cle in inputVariables.Keys)
            {
                sw.WriteLine(cle + ':' + inputVariables[cle]);
            }

            Debug.Log("saveCreated at " + Values.SavesPath + '/' + saveName + '/' + fileName + ".save");
            sw.Close();
        }

        public static void LoadSpecSave(string savePath) //Savename = nom du dir + specifique sav
        {
            if (File.Exists(savePath))
            {
                Dictionary<string, string> savedContent = ParseData(savePath);
                if (CheckData(savedContent) == false)
                {
                    Debug.Log("Data Non Valides");
                }

                Variable.SaveName = savedContent["SaveName"];
                Variable.Desk = savedContent["DeskName"].ToDesk();
                Variable.SceneNameCurrent = savedContent["SceneName"];
                string[] positonString = savedContent["Position"].Split(' ');
                positonString[0] = positonString[0].Remove(0, 1);
                positonString[0] = positonString[0].Remove(positonString[0].Length - 1, 1);
                positonString[1] = positonString[1].Remove(positonString[1].Length - 1, 1);
                Variable.LatestPos = (float.Parse(positonString[0]), (float.Parse(positonString[1])));
                Debug.Log("Partie Chargée Avec Succès");

            }

            else
            {
                Debug.Log("Erreur De Sauvegarde");
            }
        }
    }

}