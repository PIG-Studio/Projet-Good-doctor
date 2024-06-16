using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Outils
{
    public class Depression : MonoBehaviour
    {
        private static Object _mood;
        public GameObject Mood;

        void MoodOnClick()
        {
            if(GameCore.Variables.Variable.Desk.CurrentPatient == null) return;

                Debug.Log("Clique");
                PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = GameCore.Variables.Variable.Desk.CurrentPatient as PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
                Mood.GetComponent<TextMeshProUGUI>().text  = patient.Depression.Valeur.ToString();
        }

        public void Start()
        {
            _mood = Resources.Load("Prefabs/Outils/Depression");
            Instantiate(_mood);
            FindObjectOfType<Button>().onClick.AddListener(MoodOnClick);

        }
    }
}