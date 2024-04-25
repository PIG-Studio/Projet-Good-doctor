using Interfaces;
using UnityEngine;

namespace C__Scripts.Item
{
    public abstract class Item : IObject
    {
        public string Name { get; set; }
        public uint Amount { get; set; }
        public Sprite Image { get; set; }
        public delegate void Action();
        public Action OnUseAction { get; set; }
        public Item(string name, Action inAction, uint qte, Sprite image)
        {
            Name = name;
            OnUseAction = inAction;
            Amount = qte;
            Image = image;
        }

    }
}