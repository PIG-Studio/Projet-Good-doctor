using Interfaces;
using Interfaces.Objects;
using UnityEngine;
using GameCore.Constantes;
using Inventories.Slots;

namespace Inventories
{
    public class Inventory : IInventory
    {
        /// <summary>
        /// Tableau de slots représentant les emplacements de l'inventaire
        /// </summary>
        public Slot[] Slots { get; set; }
        public GameObject Object { get; set; }
        public bool HasChanged { get; set; }
        public uint Amount { get; private set; }

        public Inventory()
        {
            Slot[] obj = new Slot[Constante.InventorySize];
            // Initialise chaque slot du tableau avec un nouveau slot
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                obj[i] = new Slot();
            }

            Slots = obj;
            Amount = 0;
        }

        /// <summary>
        /// Méthode pour ajouter un objet à l'inventaire
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(IObject item)
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                // Vérifie si l'objet peut être ajouté au slot actuel
                if (Slots[i].CanAdd(item))
                {
                    Slots[i].AddItem(item);
                    HasChanged = true;
                    Amount++;
                    break;
                }
            }
        }

        /// <summary>
        /// Méthode pour retirer un objet de l'inventaire
        /// </summary>
        public void RemoveItem()
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                // Vérifie si le slot n'est pas vide
                if (Slots[i] != null)
                {
                    Slots[i].RemoveItem();
                    HasChanged = true;
                    Amount--;
                    break;
                }
            }
        }

        /// <summary>
        /// Méthode pour vérifier si un objet peut être ajouté à l'inventaire
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanAdd(IObject item)
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                // Vérifie si l'objet peut être ajouté au slot actuel
                if (Slots[i].CanAdd(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}