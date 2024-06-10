using Interfaces.Objects;
using UnityEngine;

namespace Items.Base
{
    public abstract class Item : IObject
    {
        /// <summary>
        /// Le nom de l'item
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Le montant de l'item
        /// </summary>
        public uint Amount { get; set; }
        /// <summary>
        /// Le sprite de l'item
        /// </summary>
        public Sprite Image { get; set; }
        /// <summary>
        /// Action associée à l'utilisation de l'objet
        /// </summary>
        public delegate void Action();
        /// <summary>
        /// Action à exécuter lorsque l'objet est utilisé
        /// </summary>
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