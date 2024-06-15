using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class Thermometer : MonoBehaviour
    {
        private static Object _thermometer;
        public GameObject Temp;

        void ThermhoOnClick()
        { 
            if(GameCore.Variables.Variable.Desk.CurrentPatient == null) return;
            Debug.Log("Clique");
            PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = GameCore.Variables.Variable.Desk.CurrentPatient as PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
            Temp.GetComponent<TextMeshProUGUI>().text  = patient.Temperature + " °c";
        }

        public void Start()
        {
            _thermometer = Resources.Load("Prefabs/Outils/Thermometer");
            Instantiate(_thermometer);
            FindObjectOfType<Button>().onClick.AddListener(ThermhoOnClick);

        }
    }
}