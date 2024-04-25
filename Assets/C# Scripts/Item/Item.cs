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
        public Item(string name, Action inAction, uint qte, Sprite image)
        {
            Name = name;
            Amount = qte;
            Image = image;
        }

    }
}