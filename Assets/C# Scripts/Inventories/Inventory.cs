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
}