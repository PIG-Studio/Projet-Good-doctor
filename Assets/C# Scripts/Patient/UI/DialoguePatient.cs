using UnityEngine;
using TMPro;

namespace Patient.UI
{

    public class DialoguePatient : MonoBehaviour
    {
        public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
        public TextMeshProUGUI shownText;
        //private Collider2D other;

        private void Awake()
        {
            shownText.text = Patient.Phrase;
            Debug.Log(shownText.text);
        }

        private void Start()
        {
            boiteDialogue.SetActive(true); // le dialogue commence masqu
            Debug.Log("START DIALOGUE");
        }


        private void Update()
        {

        }
    }
}