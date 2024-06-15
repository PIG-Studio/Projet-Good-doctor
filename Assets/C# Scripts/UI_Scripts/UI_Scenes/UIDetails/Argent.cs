using System;
using TMPro;
using UnityEngine;

namespace UI_Scripts.UI_Scenes
{
    public class Argent : MonoBehaviour
    {
        private uint money;

        public void Start()
        {
            money = Joueur.Base.JoueurFundamentals.Money;
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = money +  "\u20ac ";
        }

        public void Update()
        {
            transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = money +  "\u20ac ";

        }
    }
}