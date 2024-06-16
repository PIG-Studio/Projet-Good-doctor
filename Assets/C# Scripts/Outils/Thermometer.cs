using GameCore.Variables;
using Super.Interfaces.Patient;
using TMPro;
using TypeExpand.String;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Outils
{
    public class Thermometer : MonoBehaviour
    {
        private static Object _thermometer;
        [FormerlySerializedAs("Temp")] public GameObject temp;

        void ThermhoOnClick()
        { 
            if(Variable.SceneNameCurrent.ToDesk()!.CurrentPatient == null) return;
            Debug.Log("Clique");
            IPatient patient = Variable.SceneNameCurrent.ToDesk()!.CurrentPatient as IPatient;
            if (patient is null) return;
            temp.GetComponent<TextMeshProUGUI>().text  = patient!.Temperature.Valeur + " °c";
        }

        public void Start()
        {
            _thermometer = Resources.Load("Prefabs/Outils/Thermometer");
            Instantiate(_thermometer);
            FindObjectOfType<Button>().onClick.AddListener(ThermhoOnClick);

        }
    }
}