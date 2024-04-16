using Interfaces;
using Inventories;
using UnityEngine;
using static GameCore.Constantes;
using static GameCore.Variables;

public class Inventory : IInventory
{
    public Slot[] Slots { get; }
    public GameObject Object { get; set; }
    public bool HasChanged { get; set; }
    
    public Inventory()
    { 
        Slot[] obj = new Slot[Invetory_Size];
        for (int i = 0; i < Invetory_Size; i++)
        {
            obj[i] = new Slot();
        }
        Slots = obj;
    }
    
    public void AddItem(IObject item)
    {
        for (int i = 0; i < Invetory_Size; i++)
        {
            if (Slots[i].CanAdd(item))
            {
                Slots[i].AddItem(item);
                HasChanged = true;
                break;
            }
        }
    }
    
    public void RemoveItem()
    {
        for (int i = 0; i < Invetory_Size; i++)
        {
            if (Slots[i] != null)
            {
                Slots[i].RemoveItem();
                HasChanged = true;
                break;
            }
        }
    }
    
    public bool CanAdd(IObject item)
    {
        for (int i = 0; i < Invetory_Size; i++)
        {
            if (Slots[i].CanAdd(item))
            {
                return true;
            }
        }
        return false;
    }
}