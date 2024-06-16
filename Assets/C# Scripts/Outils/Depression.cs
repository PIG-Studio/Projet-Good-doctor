using GameCore.Variables;
using Super.Interfaces.Patient;
using TMPro;
using TypeExpand.String;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Outils
{
    public class Depression : MonoBehaviour
    {
        private static Object _mood;
        [FormerlySerializedAs("Mood")] public GameObject mood;

        void MoodOnClick()
        {
            if(Variable.Desk.CurrentPatient == null) return;

                Debug.Log("Clique");
                IPatient patient = Variable.SceneNameCurrent.ToDesk()!.CurrentPatient as IPatient;
                if (patient is null) return;
                mood.GetComponent<TextMeshProUGUI>().text  = patient.Depression.Valeur.ToString();
        }

        public void Start()
        {
            _mood = Resources.Load("Prefabs/Outils/Depression");
            Instantiate(_mood);
            FindObjectOfType<Button>().onClick.AddListener(MoodOnClick);

        }
    }
}