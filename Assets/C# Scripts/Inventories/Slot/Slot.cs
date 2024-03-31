using Interfaces;
using UnityEditor;
using UnityEngine;
using static GameCore.Constantes;

namespace Inventories 
{
    public class Slot : IInventory
    {
        private IObject[] Item { get; }
        public Sprite Image { get; private set; }
        public int Amount = 0;

        public Slot()
        {
            Item = new IObject[Invetory_Slot_Size];
        }
        
        public void AddItem(IObject item)
        {
            for (int i = 0; i < Invetory_Slot_Size; i++)
            {
                if (Item[i] == null)
                {
                    Item[i] = item;
                    Amount++;
                    break;
                }
            }
            
            if (Amount >= 1 && Amount < Invetory_Slot_Size)
            {
                Image = item.Image;
            }
        }
        
        public void RemoveItem()
        {
            for (int i = Invetory_Slot_Size-1; i >= 0; i--)
            {
                if (Item[i] != null)
                {
                    Item[i] = null;
                    Amount--;
                    break;
                }
            }
            
            if (Amount == 0)
            {
                Image = null;
            }
        }
        
    }
}