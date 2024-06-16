using System;
using TMPro;
using UnityEngine;

namespace UI_Scripts.UI_Scenes
{
    public class Clock : MonoBehaviour
    {
        
        private TextMeshProUGUI Text { get; set; }
        
        private int Milliseconde { get; set; }
        
        private int Seconde { get; set; }
        
        private int Minute { get; set; }
        private string Dizaine { get; set; }
        
        private bool Passe { get; set; }
        
        public void Start()
        {
            Text = GetComponent<TextMeshProUGUI>();
            Milliseconde = 0;
            Seconde = 0;
            Minute = 0;
            Passe = false;
        }

        public void CheckMilliseconde()
        {
            if (Milliseconde >= 60)
            {
                Seconde++;
                Milliseconde = 0;
            }
        }

        public void CheckSeconde()
        {
            if (Seconde >= 60)
            {
                Minute++;
                Seconde = 0;
            }
        }

        public void CheckDizaine()
        {
            if (Seconde < 10)
            {
                Dizaine = "0";
            }
            else
            {
                Dizaine = "";
            }
        }

        public void Update()
        {
            if (!(Passe))
            {
                Milliseconde++;
                CheckMilliseconde();
                CheckSeconde();
                CheckDizaine();
                Text.text = Minute.ToString() + ':' + Dizaine + Seconde;
                Passe = true;
            }
            else
            {
                Passe = false;
            }

        }
    }
}