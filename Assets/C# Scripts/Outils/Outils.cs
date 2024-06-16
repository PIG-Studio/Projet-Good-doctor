using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Outils
{
    public class Outils : MonoBehaviour
    {
        private static Object Stethoscope;
        private  static Object Thermometer;
        private  static Object Labo;
        private  static Object Scan;

        public TextMeshProUGUI Freq;
        

        void StethoOnClick()
        { 
            Debug.Log("Clique !");
            Freq.text = 120 + "BPM";
        }
        public void Start()
        {
            Stethoscope = Resources.Load("Prefabs/Outils/Stethoscope");
            Instantiate(Stethoscope); 
            FindObjectOfType<Button>(Stethoscope).onClick.AddListener(StethoOnClick);
        }
        
        void ThermoOnClick()
        {
            //set temp de fiche patient a celle du patient et desactive le button(?)
        }

        void LaboOnClick()
        {
            //Envoie une requete au labo et analyse l'adn du patient
        }
        
        void ScanOnClick()
        {
            //set Depression de fiche patient a celle du patient et desactive le button(?)
        }
        
    }
}