using Inventories.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Super.Interfaces.Inventory
{
    public interface ISlotHolder
    {
        uint Col { get; }
        GameObject PrefabSlot { get; set; }
        public IInventory Inventory { get; set; }
        
        void Start();
        void Update();
    }
}