using Interfaces;
using Inventories;
using static GameCore.Constantes;

public class Inventory : IInventory
{
    public Slot[] Slots { get; }
    
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
            if (Slots[i] == null)
            {
                Slots[i].AddItem(item);
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
                break;
            }
        }
    }
}