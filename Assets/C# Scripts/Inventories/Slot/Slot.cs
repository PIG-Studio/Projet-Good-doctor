using Interfaces;
using static GameCore.Constantes;

namespace Inventories 
{
    public class Slot : IInventory
    {
        public IObject[] Objects { get; }

        public Slot()
        {
            Objects = new IObject[Invetory_Slot_Size];
        }
    }
}