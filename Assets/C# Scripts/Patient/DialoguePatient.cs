using GameCore.GameVAR;
using TMPro;
using UnityEngine;
using Patient.Base;

namespace Patient
{
    public class DialoguePatient : MonoBehaviour
    {
        public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
        public TextMeshProUGUI text;
        public PatientBase Base;
        public Renderer bubble;
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
            bubble = boiteDialogue.GetComponent<SpriteRenderer>();
            boiteDialogue.SetActive(false); // le dialogue commence masqué
            bubble.enabled = false;
            _catchPhrase = Base.CatchPhrase;
            _name = Base.Name;
            text.text = _name;
            Vector3 pos = boiteDialogue.GetComponent<RectTransform>().position;
            boiteDialogue.GetComponent<RectTransform>().position = new Vector3(pos.x ,pos.y - 1f , pos.z);
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
                if (bubble.enabled)
                {
                    Vector3 pos = boiteDialogue.GetComponent<RectTransform>().position;
                    boiteDialogue.GetComponent<RectTransform>().position = new Vector3(pos.x ,pos.y - 1f , pos.z);    
                }
                bubble.enabled = false;
                boiteDialogue.SetActive(false);
                text.text = _name;
            }
        }

        private void Update()
        {
            if (_close && Input.GetKeyDown(Constantes.InteractKey) && bubble.enabled == false)
            {
                Vector3 pos = boiteDialogue.GetComponent<RectTransform>().position;
                boiteDialogue.GetComponent<RectTransform>().position = new Vector3(pos.x ,pos.y + 1f , pos.z);
                bubble.enabled = true;
                text.text = _catchPhrase;
            }
        }
    }
}