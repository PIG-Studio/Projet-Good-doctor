using GameCore.Variables;
using Parameters;
using ScriptableObject;
using UnityEngine;

namespace Interaction.Implementation
{
    public class ChaiseSuicide
    {
        /// <summary>
        /// Méthode appelée pour interagir avec la chaise quand on a une corde
        /// </summary>
        public PrintBubbleDescription Bubble { get; set; }
        [SerializeField] public GameObject BubbleTemp;

        public void Start()
        {
            Bubble = BubbleTemp.GetComponent<PrintBubbleDescription>();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                // FAIT POP UNE MADELAINE DANS INVENTAIRE
                if (!other.CompareTag("Player")) return;

                if (Variable.CurrentlyRenderedDesk.Responsable.Inventory.Contain("Corde"))
                {
                    Bubble.DescAct = "Vous êtes coincé dans l'hôpital st-Madeleine depuis tellement longtemps que vous utilisez la chaise pour attacher une corde au plafond et \" partez\" d'ici.";
                    //joueur meurt ?
                }
                else
                {
                    Bubble.DescAct = "Ceci est une chaise tout a fait banale. A moins que ...";
                }
                Bubble.SetActive();
            }
        }
    }
}