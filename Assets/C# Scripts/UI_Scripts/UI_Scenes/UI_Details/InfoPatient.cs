using GameCore.Variables;
using TMPro;
using TypeExpand.String;
using UnityEngine;

namespace UI_Scripts.UI_Scenes.UI_Details
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
            if (Variable.SceneNameCurrent.ToDesk()!.CurrentPatient == null)
            {
                transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Client suivant";
                transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "Client suivant";
            }

            if (Variable.SceneNameCurrent.ToDesk()!.CurrentPatient == null) return;
            PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient patient = Variable.SceneNameCurrent.ToDesk()!.CurrentPatient as
                PNJ.Mobile.CanAccessDest.CanAccessDesk.Patient;
            if (patient is null) return;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = patient.Name.Value.Value;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = patient.Age.ToString();
        }   
        

    }
}