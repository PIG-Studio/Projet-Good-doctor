using System;
using GameCore.Variables;
using Joueur.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;
using Joueur.Base;

namespace UI_Scripts.UI_Scenes
{
    public class Reputation : MonoBehaviour
    {
        private int Rep;
        public void Start()
        {
            Rep = Variable.CurrentlyRenderedDesk.Responsable.Reputation;
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + Rep.ToString(); 
        }

        public void Update()
        {
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text =
                "Reputation : " + Variable.CurrentlyRenderedDesk.Responsable.Reputation.ToString();
            transform.GetChild(0).GetComponent<Image>().enabled = Rep >= 75;
            transform.GetChild(1).GetComponent<Image>().enabled = Rep >= 50 &&  Rep < 75;
            transform.GetChild(2).GetComponent<Image>().enabled = Rep >= 25 && Rep < 50;
            transform.GetChild(3).GetComponent<Image>().enabled = Rep >= 0 && Rep < 25;
        }
    }
}