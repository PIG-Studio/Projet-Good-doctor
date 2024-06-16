using GameCore.Variables;
using Super.Interfaces.Patient;
using TMPro;
using TypeExpand.String;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Outils
{
    public class Stethoscope : MonoBehaviour
    {
        private static Object _stethoscope;
        [FormerlySerializedAs("Freq")] public GameObject freq;

        void StethoOnClick()
        { 
            if(Variable.SceneNameCurrent.ToDesk()!.CurrentPatient == null) return;
            Debug.Log("Clique !");
            IPatient patient = Variable.SceneNameCurrent.ToDesk()!.CurrentPatient as IPatient;
            if (patient is null) return;
            freq.GetComponent<TextMeshProUGUI>().text  = patient.FreqCar.Valeur + " BPM";
        }

        public void Start()
        {
            _stethoscope = Resources.Load("Prefabs/Outils/Stethoscope");
            Instantiate(_stethoscope);
            FindObjectOfType<Button>().onClick.AddListener(StethoOnClick);

        }
    }
}