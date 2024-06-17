using System;
using Interaction.Base;
using UnityEngine;
using GameCore.Variables;
using Parameters;
using ScriptableObject;


namespace Interaction.Implementation
{
    public class Distributeur : ObjectInteraction
    {
        /// <summary>
        /// Méthode appelée pour interagir avec le distributeur
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
                if (Variable.CurrentlyRenderedDesk.Responsable.Money >= 15)
                {
                    ItemsSo newItem = Resources.Load<ItemsSo>("Prefabs/Item/Madeleine").CopyItem();
                    newItem.amount = 5;
                    Variable.CurrentlyRenderedDesk.Responsable.Inventory.AddItem(newItem);
                    Variable.CurrentlyRenderedDesk.Responsable.Money -= 15;
                    Bubble.DescAct = "Vous venez de récupérer 5 madeleines du distributeur de madeleine";
                }
                else
                {
                    Bubble.DescAct = "Vous n'avez pas assez d'argent pour acheter des madeleins. \nIl vous faut au moins 15 thunas.";
                }

                Bubble.SetActive();
            }
        }
    
    }
}

