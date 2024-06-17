using TMPro;
using UnityEngine;

namespace UI_Scripts.UI_Scenes.UI_Details
{
    public class Clock : MonoBehaviour
    {
        
        private TextMeshProUGUI Text { get; set; }
        
        private int Microseconde { get; set; }
        
        private int Milliseconde { get; set; }
        
        private int Seconde { get; set; }
        
        private int Minute { get; set; }
        private string Dizaine { get; set; }
        
        private bool Passe1 { get; set; }

        private bool Passe2 { get; set; }
        
        private bool Passe3 { get; set; }
        
        private bool Passe4 { get; set; }


        public void Start()
        {
            Text = GetComponent<TextMeshProUGUI>();
            Milliseconde = 0;
            Seconde = 0;
            Minute = 0;
            Passe1 = false;
            Passe2 = false;
            Passe3 = false;
            Passe4 = false;
        }

        public void CheckMicroseconde()
        {
            if (Microseconde >= 60)
            {
                Milliseconde++;
                Microseconde = 0;
            }
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
            if (!Passe1 && !Passe2 && !Passe3 && !Passe4)
            {

                Milliseconde++;
                CheckMicroseconde();
                CheckMilliseconde();
                CheckSeconde();
                CheckDizaine();
                Text.text = Minute.ToString() + ':' + Dizaine + Seconde;
                Passe1 = true;
                Passe2 = true;
                Passe3 = true;
                Passe4 = true;
            }
            if (Passe4 && !Passe3 && !Passe2 && !Passe1) Passe4 = false;
            if (Passe4 && Passe3 && !Passe2 && !Passe1) Passe3 = false;
            if (Passe4 && Passe3 && Passe2 && !Passe1) Passe2 = false;
            if (Passe4 &&  Passe3 && Passe2 && Passe1) Passe1 = false;
        }
    }
}