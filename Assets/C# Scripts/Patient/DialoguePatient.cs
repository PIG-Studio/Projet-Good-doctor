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
        private TextMeshProUGUI TextArea { get; set; }
        private APnj Patient { get; set; }
        private GameObject ChildCanvas { get; set; }
        private SpriteRenderer BubbleRender { get; set; }
        private RectTransform RectDialogue { get; set; }

        private void Start()
        {
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


        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("TriggerEnter2D");
            if (Variable.SceneNameCurrent != Scenes.Map || !other.CompareTag("Player") || !other.GetComponent<PlayerController.Multi.Multi>().IsOwner) return;
            
            ChildCanvas.SetActive(true);
        }
    
    

        public void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("TriggerExit2D");
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
            
            if (!ChildCanvas.activeSelf) return;    
            if (!Input.GetKeyDown(Constante.InteractKey)) return;
            
            Vector3 pos = RectDialogue.position;
            switch (BubbleRender.enabled)
            {
                case false:
                {
                    RectDialogue.position = new Vector3(pos.x, pos.y - 1f, pos.z);
                    TextArea.text = Patient.Phrase;
                    BubbleRender.enabled = true;
                    Debug.Log("Bubble enabled");
                    break;
                }
                    
                case true:
                {
                    RectDialogue.position = new Vector3(pos.x, pos.y + 1f, pos.z);
                    TextArea.text = Patient.Name;
                    BubbleRender.enabled = false;
                    Debug.Log("Bubble disabled");
                    break;
                }
            }
        }
        
        
    }
}