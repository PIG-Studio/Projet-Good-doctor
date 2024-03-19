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
        string[] sepa = saveName.Split('@');
        StreamReader sr = new StreamReader(PARAM_Values.SavesPath + '/' + sepa[0] + saveName);
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
        if (Directory.Exists(PARAM_Values.SavesPath +
        '/' + saveName) == false)
        {
            Directory.CreateDirectory(PARAM_Values.SavesPath
                                                                      + '/' + saveName);
            File.Create(PARAM_Values.SavesPath + '/' + 
                        saveName + '/' + fileName + ".save").Close();
        }
        else
        {
            File.Create(PARAM_Values.SavesPath + '/' +
                        saveName + '/' + fileName + ".save").Close();
        }
        string lol = Directory.GetLastWriteTime(PARAM_Values.SavesPath).ToString("G");
        lol = lol.Replace(':', '.');
        lol = lol.Replace('/', '_');
        File.Create(PARAM_Values.SavesPath + '/' +
                    saveName + '/' + lol).Close();
        StreamWriter sw = new StreamWriter(PARAM_Values.SavesPath + '/' + saveName + '/' + fileName + ".save");
        foreach (var cle in inputVariables.Keys)
        {
            sw.WriteLine(cle + ':' + inputVariables[cle]);
        }
        Debug.Log("saveCreated at " + PARAM_Values.SavesPath + '/' + saveName + '/' + fileName + ".save");
        sw.Close();
    }

    public void Load(string SaveName) //Savename = nom du dir + nom de la save
    {
        string[] SaveFiles = Directory.GetFiles(PARAM_Values.SavesPath + SaveName.Split('/')[0]);
        bool validpath = false;
        foreach (var Lapin in SaveFiles)
        {
            if (Lapin.Contains(GameVariables.SaveName))
            {
                validpath = true;
            }
        }
        if (validpath)
        {
            Dictionary<string, string> savedContent = ParseData(GameVariables.SaveName);
            if (CheckData(savedContent) == false)
            {
                Debug.Log("Data Non Valides");
            }

            GameVariables.SaveName = savedContent["SaveName"];
            GameVariables.DeskName = DesksConvert.ToDesk(savedContent["DeskName"]);
            GameVariables.SceneName_Current = savedContent["SceneName"];
            string[] DemiCanard = savedContent["Position"].Split(' ');
            DemiCanard[0] = DemiCanard[0].Remove(0, 1);
            DemiCanard[0] = DemiCanard[0].Remove(DemiCanard[0].Length - 1, 1);
            DemiCanard[1] = DemiCanard[1].Remove(DemiCanard[1].Length - 1, 1);
            GameVariables.LatestPos = (float.Parse(DemiCanard[0]), (float.Parse(DemiCanard[1])));
            Debug.Log("Partie Chargée Avec Succès");

        }
        else
        {
            Debug.Log("Erreur De Sauvegarde");
        }
    }
}
