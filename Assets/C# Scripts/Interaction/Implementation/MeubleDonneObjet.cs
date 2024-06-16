using GameCore.Variables;
using Parameters;
using ScriptableObject;
using UnityEngine;

namespace Interaction.Implementation
{
    public class MeubleDonneObjet : MonoBehaviour
    {
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
        /// </summary>
        public PrintBubbleDescription Bubble { get; set; }
        [SerializeField] public GameObject BubbleTemp;
        [SerializeField] public ItemsSo item;
        public void Start()
        {
            Bubble = BubbleTemp.GetComponent<PrintBubbleDescription>();
        }

        public void OnTriggerStay2D(Collider2D other)
        {
            if (Input.GetKeyDown(Keys.UseKey) && other.CompareTag("Player"))
            {
                // FAIT POP UN objet choisit dans l'inventaire
                if (!other.CompareTag("Player")) return;
                ItemsSo newitem = item.CopyItem();
                Variable.CurrentlyRenderedDesk.Responsable.Inventory.AddItem(newitem);

                Bubble.DescAct = "Vous venez de trouver un nouvel objet !";
                Bubble.SetActive();
                
                Destroy(gameObject);
            }
        }
    }
}