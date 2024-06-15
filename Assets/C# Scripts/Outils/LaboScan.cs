using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class LaboScan : MonoBehaviour
    {
        private static Object _labo;
        public GameObject ADN;

        void LaboOnClick()
        { 
            if(GameCore.Variables.Variable.Desk.CurrentPatient == null) return;
            Debug.Log("Clique");
            PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = GameCore.Variables.Variable.Desk.CurrentPatient as PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
            ADN.GetComponent<TextMeshProUGUI>().text  = patient.Adn.ToString();
        }

        public void Start()
        {
            _labo = Resources.Load("Prefabs/Outils/Labo");
            Instantiate(_labo);
            FindObjectOfType<Button>().onClick.AddListener(LaboOnClick);

        }
    }
}