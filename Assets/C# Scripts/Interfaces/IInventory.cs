using UnityEngine;

namespace Interfaces
{
    public interface IInventory
    {
        public GameObject Object { get; set; }
        public bool HasChanged { get; set; }
        public void AddItem(IObject item);
        public void RemoveItem();
        public bool CanAdd(IObject item);
    }
}