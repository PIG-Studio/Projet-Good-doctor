using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SaveLoadMethods : MonoBehaviour
{
    
    private static string[] ListAllSaves()
    {
        string[] res = Directory.GetFiles(PARAM_Values.SavesPath,"*.save");
        return res;
    }

    private static bool NumbInString(string Madelaine)
    {
        foreach (var miettes in Madelaine)
        {
            if (miettes - '0' >= 0 && miettes - '0' <= 9)
            {
                return true;
            }
        }

        return false;
    }
    
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
        StreamReader sr = new StreamReader(PARAM_Values.SavesPath + '/' + saveName);
        string line = sr.ReadLine();
        string cle, valeur;
        string[] lineSplitted;
        Dictionary<string, string> retour = new Dictionary<string, string>();

        while (line != null)
        {
            lineSplitted = line.Split(':');
            (cle, valeur) = (lineSplitted[0], lineSplitted[1]);//valeur est un gamevariable
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
    
    public static bool CheckData(Dictionary<string,string> ParsedData)
    {
        foreach (var miettes in ParsedData)
        {
            if (miettes.Key == "SaveName")
            {
                if (File.Exists(PARAM_Values.SavesPath + '/' + miettes.Value))
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
                if (NumbInString(miettes.Value) == false)
                {
                    return false;
                }
            }

            if (miettes.Key == "DeskName")
            {
                if (DesksConvert.ValidString(miettes.Value) == false)
                {
                    return false;
                }
            }

            if (miettes.Key == "SceneName")
            {
                try
                {
                    CustomSceneManager.ChangeScene(miettes.Value);
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
        string saveName = GameVariables.SaveName;
        // TODO : ecrire les variables dans un fichier .json ?
        string fileName = saveName + "@" + date;
        File.Create(Directory.GetCurrentDirectory()+ '\\' + fileName + ".save").Close();
        StreamWriter sw = new StreamWriter(PARAM_Values.SavesPath + '/' + fileName + ".save");
        foreach (var cle in inputVariables.Keys)
        {
            sw.WriteLine(cle + ':' + inputVariables[cle]);
        }
        Debug.Log("saveCreated at " + PARAM_Values.SavesPath + '/' + fileName + ".save");
        sw.Close();
    }

    public void Load()
    {
        string[] SaveFiles = Directory.GetFiles(PARAM_Values.SavesPath);
        if (SaveFiles.Contains(GameVariables.SaveName))
        {
            Dictionary<string, string> SavedContent = ParseData(GameVariables.SaveName);
            if (CheckData(SavedContent) == false)
            {
                Debug.Log("Data Non Valides");
            }

            GameVariables.SaveName = SavedContent["SaveName"];
            GameVariables.LatestPos = SavedContent["position"];
        }
    }
}
