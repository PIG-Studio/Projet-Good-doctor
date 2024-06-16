using Maladies.Base.SubTypes;
using Super.Interfaces.Patient;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Outils
{
    public class LaboScan : MonoBehaviour
    {
        private static Object _labo;
        [FormerlySerializedAs("Adn")] [FormerlySerializedAs("ADdn")] [FormerlySerializedAs("ADN")] public GameObject adn;

        void LaboOnClick()
        { 
            if(GameCore.Variables.Variable.Desk.CurrentPatient == null) return;
            Debug.Log("Clique");
            IPatient patient = GameCore.Variables.Variable.Desk.CurrentPatient as 
                IPatient;
            if (patient == null) return;
            Adn adn2 = patient.Adn as Adn;
            adn.GetComponent<TextMeshProUGUI>().text  = adn2!.AdnValue;
        }

        public void Start()
        {
            _labo = Resources.Load("Prefabs/Outils/Labo");
            Instantiate(_labo);
            FindObjectOfType<Button>().onClick.AddListener(LaboOnClick);

        }
    }
}