using JetBrains.Annotations;
using Parameters;
using ScriptableObject;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

namespace Inventories.Player
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

        void UpdateDescription(uint i);
        void AddItem(ItemsSo item);
        void RemoveItem(ItemsSo item);
        void GiveItem(ItemsSo item, IInventory inventory);
    }
}