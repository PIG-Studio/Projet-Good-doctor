using JetBrains.Annotations;
using ScriptableObject;
using UnityEngine;

namespace Super.Interfaces.Inventory
{
    public interface IInventory 
    {
        public ItemsSo[] Inventaire { get; set; }
        [CanBeNull] public  string NomActuel { get; set; }
        [CanBeNull] public Sprite ImageActuel { get; set; }
        [CanBeNull] public string DescActuelle { get; set; }
        public uint MaxLenght { get; }

        public void Start();
        public void Update();

        void PrintDescription(uint i);
        void AddItem(ItemsSo item);
        void RemoveItem(ItemsSo item);
        void GiveItem(ItemsSo item, IInventory inventory);
    }
}