using Interfaces;
using JetBrains.Annotations;
using UnityEngine;
using static GameCore.Constantes;

namespace Inventories 
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
        [NotNull] public int Amount;
        
        // Le GameObject du slot
        [CanBeNull] public GameObject Object { get; set; }
        
        // Bool si on doit actualiser l'UI
        [NotNull]public bool HasChanged { get; set; }

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
            for (int i = 0; i < Invetory_Slot_Size; i++)
            {Debug.Log($"{Type} et {item.GetType()} donne {Type == item.GetType()}");
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
            for (int i = Invetory_Slot_Size-1; i >= 0; i--)
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
        
        public bool CanAdd(IObject item)
        {
            if (Amount < Invetory_Slot_Size && (Type == null || Type == item.GetType())) { return true; }
            return false;
        }
        
    }
}