using TMPro;
using UnityEngine;

namespace Patient
{
    public class DialoguePatient : MonoBehaviour
    {
        public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
        public TextMeshProUGUI text;
        public Patient patient;
        private string _catchPhrase;
        private string _name;
        private bool _close;
        private void Awake()
        {
            _close = false;
        }

        private void Start()
        {
            boiteDialogue = gameObject.transform.GetChild(0).gameObject;
            text = boiteDialogue.gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            boiteDialogue.SetActive(false); // le dialogue commence masqué
            _catchPhrase = patient.CatchPhrase;
            _name = patient.Name;
            text.text = _name;
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _close = true;
                boiteDialogue.SetActive(true);
            }
        }
    
    

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _close = false; 
                boiteDialogue.SetActive(false);
                text.text = _name;
            }
        }

        private void Update()
        {
            if (_close && Input.GetKeyDown(KeyCode.T))
            {
                text.text = _catchPhrase;
            }
        }
    }
}