using Parameters;
using UnityEngine;
using UnityEngine.Serialization;

namespace Interaction.Implementation
{
    public class Porte : MonoBehaviour
    {
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
        /// </summary>
        public PrintBubbleDescription Bubble { get; set; }
        [FormerlySerializedAs("BubbleTemp")] [SerializeField] public GameObject bubbleTemp;
        public void Start()
        {
            Bubble = bubbleTemp.GetComponent<PrintBubbleDescription>();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                // FAIT POP UN objet choisit dans l'inventaire
                if (!other.CompareTag("Player")) return;
                
                Bubble.DescAct = "Vous ne pouvez partir. Vous êtes coincé ici, dans l'hôpital st-Madeleine, pour toujours. \nBienvenue dans le monde du travail.";
                Bubble.SetActive();
            }
        }
    }
}