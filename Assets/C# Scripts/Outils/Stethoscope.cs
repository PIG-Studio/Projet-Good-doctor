using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Outils
{
    public class Stethoscope : MonoBehaviour
    {
        private static Object _stethoscope;
        public GameObject Freq;

        void StethoOnClick()
        { 
            if(GameCore.Variables.Variable.Desk.CurrentPatient == null) return;
            Debug.Log("Clique !");
            PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = GameCore.Variables.Variable.Desk.CurrentPatient as PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
            Freq.GetComponent<TextMeshProUGUI>().text  = patient.FreqCar + " BPM";
        }

        public void Start()
        {
            _stethoscope = Resources.Load("Prefabs/Outils/Stethoscope");
            Instantiate(_stethoscope);
            FindObjectOfType<Button>().onClick.AddListener(StethoOnClick);

        }
    }
}