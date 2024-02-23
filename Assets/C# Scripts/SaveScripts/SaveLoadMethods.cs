using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class SaveLoadMethods : MonoBehaviour
{

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

    public static bool CheckData(Dictionary<string, string> ParsedData)
    {
        foreach (var elts in ParsedData)
        {
            if (elts.Key == "SaveName" && ValidNameToSave(elts.Value) == false)
            {
                return false;
            }

            if (elts.Key == "Position" && NumbInString(elts.Value))
            {
                return false;
            }
        }

        return true;
    }
    
    public Dictionary<string, string> ListAvailableSaves_Latest()
    {

        // TODO : lis tout les fichiers d un dossier, si nom, extension et data du fichier sont a un fornat valide, ajouter le fichier la liste
        //SARTO
        
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
}
