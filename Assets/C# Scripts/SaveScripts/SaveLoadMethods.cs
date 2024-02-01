using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoadMethods : MonoBehaviour
{
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
            (cle, valeur) = (lineSplitted[0], lineSplitted[1]);
            if (lineSplitted.Length != 2)
                return null;
            retour[cle] = valeur;
            line = sr.ReadLine();
        }
        
        sr.Close();
        return retour;
    }
    
    public Dictionary<string, string> ListAvailableSaves_Latest()
    {
        // TODO : lis tout les fichiers d un dossier, si nom, extension et data du fichier sont a un fornat valide, ajouter le fichier la liste
        return new Dictionary<string, string>();
    }
    
    public Dictionary<string, string> ListAvailableSaves_Detailled()
    {
        // TODO : lis tout les fichiers d un dossier, si nom, extension et data du fichier sont a un fornat valide, ajouter le fichier la liste
        return new Dictionary<string, string>();
    }
  
    public static void WriteSaveGame(Dictionary<string, string> inputVariables)
    {
        string date = DateTime.Now.ToString("O");
        string saveName = GameVariables.SaveName;
        // TODO : ecrire les variables dans un fichier .json ?
        string fileName = saveName + '@' + date;
        File.Create(PARAM_Values.SavesPath + '/' + fileName).Close();
        StreamWriter sw = new StreamWriter(PARAM_Values.SavesPath + '/' + fileName);
        foreach (var cle in inputVariables.Keys)
        {
            sw.WriteLine(cle + ':' + inputVariables[cle]);
        }
        Debug.Log("saveCreated at " + PARAM_Values.SavesPath + '/' + fileName);
        sw.Close();
    }

    public static bool ValidNameToSave(string testStr)
    {
        bool retour = true;
        if (testStr.Length < 3)
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
}
