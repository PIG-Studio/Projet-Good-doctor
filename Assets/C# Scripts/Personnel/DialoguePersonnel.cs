

using CustomScenes;
using GameCore.Constantes;
using GameCore.Variables;
using Super.Abstract;
using TMPro;
using Unity.Netcode;
using UnityEngine;

namespace Personnel
{
    public class DialoguePersonnel
    {
        public class DialoguePatient : NetworkBehaviour
    {
        /// <summary>
        /// Texte affichant le dialogue du patient.
        /// </summary>
        private TextMeshProUGUI TextArea { get; set; }
        /// <summary>
        /// Script représentant le patient.
        /// </summary>
        private APnj Patient { get; set; }
        /// <summary>
        /// Canvas contenant le dialogue.
        /// </summary>
        private GameObject ChildCanvas { get; set; }
        /// <summary>
        /// Sprite du dialogue.
        /// </summary>
        private SpriteRenderer BubbleRender { get; set; }
        /// <summary>
        /// Rectangle du dialogue.
        /// </summary>
        private RectTransform RectDialogue { get; set; }

        private void Start()
        {
             // Initialisation des éléments de dialogue
            ChildCanvas = transform.GetChild(0).gameObject;
            TextArea = ChildCanvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            Patient = GetComponent<APnj>();
            BubbleRender = ChildCanvas.GetComponent<SpriteRenderer>();
            
            TextArea.text = Patient.Name;
            BubbleRender.enabled = false;
            
            RectDialogue = ChildCanvas.GetComponent<RectTransform>();
            Vector3 pos = RectDialogue.position;
            RectDialogue.position = new Vector3(pos.x ,pos.y - 1f , pos.z);
            ChildCanvas.SetActive(false); // le dialogue commence masqué
        }


        /// <summary>
        /// Appelée lorsque le joueur entre en collision avec le patient
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("TriggerEnter2D");
            // Activation du dialogue si le joueur est propriétaire et sur la carte
            if (Variable.SceneNameCurrent != Scenes.Map || !other.CompareTag("Player") || !other.GetComponent<PlayerController.Multi.Multi>().IsOwner) return;
            
            ChildCanvas.SetActive(true);
        }
    
    

        /// <summary>
        /// Appelée lorsque le joueur quitte la zone du patient
        /// </summary>
        /// <param name="other"></param>
        public void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("TriggerExit2D");
            // Désactivation du dialogue lorsque le joueur quitte
            if (!other.CompareTag("Player") || !other.GetComponent<PlayerController.Multi.Multi>().IsOwner) return;
            ChildCanvas.SetActive(false);
            Vector3 pos;
            switch (BubbleRender.enabled)
            {
                case true:
                    pos = RectDialogue.position;
                    RectDialogue.position = new Vector3(pos.x ,pos.y + 1f , pos.z);
                    TextArea.text = Patient.Name;
                    BubbleRender.enabled = false;
                    break;
            }
        }

        private void Update()
        {
            // Sortir si le dialogue n'est pas actif 
            // Sortir si la touche d'interaction n'est pas enfoncée
            if (!ChildCanvas.activeSelf) return;    
            if (!Input.GetKeyDown(Constante.InteractKey)) return;
            
            Vector3 pos = RectDialogue.position;
            switch (BubbleRender.enabled)
            {
                case false:
                {
                     // Si la bulle de dialogue est désactivée, l'activer et afficher le texte du patient
                    RectDialogue.position = new Vector3(pos.x, pos.y - 1f, pos.z);
                    TextArea.text = Patient.Phrase;
                    BubbleRender.enabled = true;
                    Debug.Log("Bubble enabled");
                    break;
                }
                    
                case true:
                {
                    // Si la bulle de dialogue est activée, la désactiver et afficher le nom du patient
                    RectDialogue.position = new Vector3(pos.x, pos.y + 1f, pos.z);
                    TextArea.text = Patient.Name;
                    BubbleRender.enabled = false;
                    Debug.Log("Bubble disabled");
                    break;
                }
            }
        }
        
        
    }
        /*
        public GameObject boiteDialogue; // référence à la boîte de dialogue public static Type Text { get; }
        public TextMeshProUGUI text;
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
            _catchPhrase = personnel._;
            _name = patient.Name;
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
    }*/
    }
}