using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Interfaces;
using Parameters;

namespace Menu
{
    public class LastSave : MonoBehaviour, IDropdownable
    {
        [FormerlySerializedAs("SavesDropDown")] [SerializeField]
        private TMP_Dropdown savesDropDown;

        private List<string> _savesName = new List<string>();

        public void Start()
            /*
             methode appele des que le bouton est rendu pour la 1e fois,
             on y verifie quelles options sont affichables selon l'OS
             */
        {
            savesDropDown.onValueChanged.AddListener(SetSaves);
            string[] allSaves = Directory.GetDirectories(Values.SavesPath);
            int index = 0;
            Debug.Log("LAST SAVE:" + allSaves[0]);
            while (index < 10 && index < allSaves.Length)
            {
                _savesName.Add(allSaves[index].Remove(0, Values.SavesPath.Length + 1));
                index++;
            }

            Debug.Log("LASTSAVE2:" + _savesName[0]);
            savesDropDown.AddOptions(_savesName);
        }

        public void SetSaves(int save)
        {
            SaveLoadMethods.LoadSpecSave(_savesName[save]);
        }

        public void SetDropdown(TMP_Dropdown dropdown)
        {
            savesDropDown = dropdown;
        }
    }
}