using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction.Implementation
{
    public class Bureau : MonoBehaviour
    {
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
        /// </summary>
        public PrintBubbleDescription Bubble { get; set; }
        [FormerlySerializedAs("BubbleTemp")] [SerializeField] public GameObject bubbleTemp;
        [SerializeField] public string number;
        public void Start()
        {
            Bubble = bubbleTemp.GetComponent<PrintBubbleDescription>();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // FAIT POP UN objet choisit dans l'inventaire
                if (!other.CompareTag("Player")) return;
                
                Bubble.DescAct = "Le bureau" + number;
                Bubble.SetActive();
            }
        }
    }
}