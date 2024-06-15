using System;
using Joueur.Base;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace UI_Scripts.UI_Scenes
{
    public class Reputation : MonoBehaviour
    {
        public void Start()
        {
            transform.GetChild(0).GetComponent<Image>().enabled = true;
            transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "Reputation : 100";
        }

        public void Update()
        {
            
        }
    }
}