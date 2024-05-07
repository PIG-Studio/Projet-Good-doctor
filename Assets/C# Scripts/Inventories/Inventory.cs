using Interfaces;
using Interfaces.Objects;
using UnityEngine;
using GameCore.Constantes;
using Inventories.Slots;

namespace Inventories
{
    public class Inventory : IInventory
    {
        public Slot[] Slots { get; set; }
        public GameObject Object { get; set; }
        public bool HasChanged { get; set; }
        public uint Amount { get; private set; }

        public Inventory()
        {
            Slot[] obj = new Slot[Constante.InventorySize];
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                obj[i] = new Slot();
            }

            Slots = obj;
            Amount = 0;
        }

        public void AddItem(IObject item)
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                if (Slots[i].CanAdd(item))
                {
                    Slots[i].AddItem(item);
                    HasChanged = true;
                    Amount++;
                    break;
                }
            }
        }

        public void RemoveItem()
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                if (Slots[i] != null)
                {
                    Slots[i].RemoveItem();
                    HasChanged = true;
                    Amount--;
                    break;
                }
            }
        }

        public bool CanAdd(IObject item)
        {
            for (int i = 0; i < Constante.InventorySize; i++)
            {
                if (Slots[i].CanAdd(item))
                {
                    return true;
                }
            }

            return false;
        }
    }
}