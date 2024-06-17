using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Outils
{
    public class Outils : MonoBehaviour
    {
        private static Object _stethoscope;
        private  static Object _thermometer;
        private  static Object _labo;
        private  static Object _scan;

        [FormerlySerializedAs("Freq")] public TextMeshProUGUI freq;
        

        void StethoOnClick()
        { 
            Debug.Log("Clique !");
            freq.text = 120 + "BPM";
        }
        public void Start()
        {
            _stethoscope = Resources.Load("Prefabs/Outils/Stethoscope");
            Instantiate(_stethoscope); 
            FindObjectOfType<Button>(_stethoscope).onClick.AddListener(StethoOnClick);
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