using CustomScenes;
using GameCore.Constantes;
using GameCore.Variables;
using TMPro;
using UnityEngine;
using Super.Abstract;
using Unity.Netcode;

namespace Patient
{
    public class DialoguePatient : NetworkBehaviour
    {
        /// <summary>
        /// Texte affichant le dialogue du patient
        /// </summary>
        private TextMeshProUGUI TextArea { get; set; }
        /// <summary>
        /// Script représentant le patient
        /// </summary>
        private APnj Patient { get; set; }
        
        /// <summary>
        /// Canvas contenant le dialogue
        /// </summary>
        private GameObject ChildCanvas { get; set; }
        
        /// <summary>
        /// Sprite du dialogue
        /// </summary>
        private SpriteRenderer BubbleRender { get; set; }
        /// <summary>
        /// Rectangle du dialogue
        /// </summary>
        private RectTransform RectDialogue { get; set; }

        private void Start()
        {
            // Initialisation des éléments de dialogue
            ChildCanvas = transform.GetChild(0).gameObject;
            TextArea = ChildCanvas.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
            Patient = GetComponent<APnj>();
            BubbleRender = ChildCanvas.GetComponent<SpriteRenderer>();
            
            TextArea.text = Patient.Name.Value.ToString();
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
                    TextArea.text = Patient.Name.Value.ToString();
                    BubbleRender.enabled = false;
                    break;
            }
        }

        private void Update()
        {
            // Sortir si le dialogue n'est pas actif
            // Si la touche d'interaction n'est pas enfoncée
            if (!ChildCanvas.activeSelf) return;    
            if (!Input.GetKeyDown(Constante.InteractKey)) return;
            
            Vector3 pos = RectDialogue.position;
            switch (BubbleRender.enabled)
            {
                // Si la bulle de dialogue est désactivée, l'activer et afficher le texte du patient
                case false:
                {
                    RectDialogue.position = new Vector3(pos.x, pos.y - 1f, pos.z);
                    TextArea.text = Patient.Phrase;
                    BubbleRender.enabled = true;
                    Debug.Log("Bubble enabled");
                    break;
                }
                // Si la bulle de dialogue est activée, la désactiver et afficher le nom du patient
                case true:
                {
                    RectDialogue.position = new Vector3(pos.x, pos.y + 1f, pos.z);
                    TextArea.text = Patient.Name.Value.ToString();
                    BubbleRender.enabled = false;
                    Debug.Log("Bubble disabled");
                    break;
                }
            }
        }
        
        
    }
}