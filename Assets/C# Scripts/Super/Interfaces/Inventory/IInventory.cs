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
        public uint QuantiteAUtiliser { get; set; }
        public uint QuantiteAct { get; set; }
        public uint IndexActuel { get; set; }
        public uint MaxLenght { get; }

        public void Start();
        public void Update();

        void UpdateDescription(uint i);
        void AddItem(ItemsSo item);
        void RemoveItem();
        void GiveItem();
        void UseItem();

        void minusB();
        void plusB();
    }
}