using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LastSave: MonoBehaviour, IDropdownable
{
    [SerializeField] private TMP_Dropdown SavesDropDown;
    private List<string> _SavesName = new List<string>();
    
    public void Start()
        /*
         methode appele des que le bouton est rendu pour la 1e fois,
         on y verifie quelles options sont affichables selon l'OS
         */
    {
        SavesDropDown.onValueChanged.AddListener(SetSaves);
        string[] AllSaves = Directory.GetDirectories(PARAM_Values.SavesPath);
        int index = 0;
        Debug.Log("LAST SAVE:" + AllSaves[0]);
        while (index < 10 && index < AllSaves.Length  )
        {
            _SavesName.Add(AllSaves[index].Remove(0,PARAM_Values.SavesPath.Length+1));
            index++;
        }
        Debug.Log("LASTSAVE2:" + _SavesName[0]);
        SavesDropDown.AddOptions(_SavesName);
    }
    
    public void SetSaves(int Save)
    {
        SaveLoadMethods.LoadSpecSave(_SavesName[Save]);
    }
    
    public void SetDropdown(TMP_Dropdown dropdown)
    {
        SavesDropDown = dropdown;
    }
}