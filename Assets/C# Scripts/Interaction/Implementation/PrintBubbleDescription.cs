using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;

namespace Interaction.Implementation
{
    public class PrintBubbleDescription : MonoBehaviour
    {
        [FormerlySerializedAs("Bubble UI")] [SerializeField] public GameObject BubbleUi;
        public TextMeshProUGUI Desc { get; set; }
        
        public string DescAct { get; set; }

        public void Start()
        {
            Desc = BubbleUi.transform.Find("Image").Find("Text").GetComponent<TextMeshProUGUI>();
            DescAct = "";
        }

        public void Update()
        {
            Desc.text = DescAct;
            if (Input.GetKeyDown(KeyCode.Space)) //quand i est pressé et que l'UI n'est pas activé 
            {
                BubbleUi.transform.Find("Image").gameObject.SetActive(false);
            }
        }

        public void SetActive()
        {
            Debug.Log("print ui interactible object");
            BubbleUi.transform.Find("Image").gameObject.SetActive(true);
        }
    }
}