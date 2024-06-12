using System;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class Outils : MonoBehaviour
    {
        private static Button StethoscopeButton;
        
        private static Button ThermoButton;
        
        private static Button LaboButton;
        
        private static Button ScanMentalButton;

        public void Start()
        {
            Instantiate(Resources.Load("Prefabs/Outils/Stethoscope"));
            Instantiate(Resources.Load("Prefabs/Outils/Labo"));
            Instantiate(Resources.Load("Prefabs/Outils/Thermometer"));
            Instantiate(Resources.Load("Prefabs/Outils/ScanMentalHealth"));
        }

        /*
         void HandleClick()
         {
            desactive les boutons si leur val est different de client suivant
        }
        */
        
        void StethoOnClick()
        {
            //set freq de fiche patient a celle du patient et desactive le button(?)
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