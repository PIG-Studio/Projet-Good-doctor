using System;
using Desks;
using GameCore.Variables;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts.UI_Scenes.UIDetails
{
    public class Attente : MonoBehaviour
    {
        public void Start()
        {
            transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Aucun Patient En Attente";
            transform.GetChild(1).GetComponent<Image>().enabled = false;
        }

        public void Update()
        {
            if (Variable.Desk.AssociatedDestination.DeskQueue.Count > 0)
            {
                transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Un Patient Vous Attend Devant " +
                    "Votre Bureau !";
                transform.GetChild(1).GetComponent<Image>().enabled = true;

            }
            if(Variable.Desk.AssociatedDestination.DeskQueue.Count > 0)return;
            transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = "Aucun Patient En Attente";
            transform.GetChild(1).GetComponent<Image>().enabled = false;
        }
    }
}