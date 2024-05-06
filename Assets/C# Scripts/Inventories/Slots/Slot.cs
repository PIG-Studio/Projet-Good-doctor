using Interfaces;
using Interfaces.Objects;
using JetBrains.Annotations;
using UnityEngine;
using GameCore.Constantes;

namespace Inventories.Slots 
{
    public class Slot : IInventory
    {
        // La liste des objets dans le slot
        //[NotNull] public IObject[] Item { get; }
        
        // Le spinner de l'objet
        [CanBeNull] public Sprite Image { get; set; }
        
        // Le type de l'objet
        [CanBeNull] public System.Type Type;
        
        // Le nombre d'objet(s) dans le slot
        public int Amount;
        
        // Le GameObject du slot
        [CanBeNull] public GameObject Object { get; set; }
        
        // Bool si on doit actualiser l'UI
        public bool HasChanged { get; set; }

        public Slot()
        {
            //Item = new IObject[Invetory_Slot_Size];
            Amount = 0;
        }
        
        /// <summary>
        /// Methode pour ajouter un item dans le slot 
        /// </summary>
        /// <param name="item">Objet implementant IObject</param>
        public void AddItem(IObject item)
        {
            for (int i = 0; i < Constante.InventorySlotSize; i++)
            {
                
                Debug.Log($"{Type} et {item.GetType()} donne {Type == item.GetType()}");
                if (Type == null || (Type == item.GetType() /*&& Item[i] == null*/))
                {
                    //Item[i] = item;
                    Amount++;
                    HasChanged = true;
                    Type = item.GetType();
                    Image = item.Image;
                    break;
                }
            }
            
            Debug.Log($"Used {Amount} out of 3 slots");
        }
        
        public void RemoveItem()
        {
            for (int i = Constante.InventorySlotSize-1; i >= 0; i--)
            {
                if (Type != null)
                {
                    Amount--;
                    HasChanged = true;
                    break;
                }
            }
            
            if (Amount == 0)
            {
                Image = null;
                Type = null;
            }
        }
        
        /// <summary>
        /// Methode verifiant si place pour ajouter objet
        /// </summary>
        /// <param name="item"></param>
        /// <returns>booleen</returns>
        public bool CanAdd(IObject item)
        {
            if (Amount < Constante.InventorySlotSize && (Type == null || Type == item.GetType())) { return true; }
            return false;
        }
        
    }
}