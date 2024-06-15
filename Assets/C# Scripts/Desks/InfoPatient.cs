using System;
using TMPro;
using UnityEngine;

namespace Desks
{
    public class InfoPatient : MonoBehaviour
    {
        public void Start()
        {
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Client suivant";
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Client suivant";
        }

        public void Update()
        {
            if (GameCore.Variables.Variable.Desk.CurrentPatient == null)
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Client suivant";
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Client suivant";
            }
            else
            {
                PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = GameCore.Variables.Variable.Desk.CurrentPatient as
                    PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = patient.name;
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = patient.Age.ToString();

            }
        }
    }
}