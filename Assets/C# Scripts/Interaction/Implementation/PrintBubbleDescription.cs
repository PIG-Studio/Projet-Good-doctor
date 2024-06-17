using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction.Implementation
{
    public class PrintBubbleDescription : MonoBehaviour
    {
        [FormerlySerializedAs("BubbleUi")] [FormerlySerializedAs("Bubble UI")] [SerializeField] public GameObject bubbleUi;
        public TextMeshProUGUI Desc { get; set; }
        
        public string DescAct { get; set; }

        public void Start()
        {
            Desc = bubbleUi.transform.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();
            DescAct = "";
        }

        public void Update()
        {
            Desc.text = DescAct;
            if (Input.GetKeyDown(KeyCode.Space)) //quand i est pressé et que l'UI n'est pas activé 
            {
                bubbleUi.transform.Find("Image").gameObject.SetActive(false);
            }
        }

        public void SetActive()
        {
            Debug.Log("print ui interactible object");
            bubbleUi.transform.Find("Image").gameObject.SetActive(true);
        }
    }
}