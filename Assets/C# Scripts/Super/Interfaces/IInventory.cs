using UnityEngine;
using Interfaces.Objects;

namespace Interfaces
{
    public interface IInventory
    {
        /// <summary>
        /// L'objet
        /// </summary>
        public GameObject Object { get; set; }
        
        /// <summary>
        /// Vérifie si l'inventaire a changé
        /// </summary>
        public bool HasChanged { get; set; }
        
        /// <summary>
        /// Ajoute un objet à l'inventaire
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(IObject item);
        
        /// <summary>
        /// Retire un objet de l'inventaire
        /// </summary>
        public void RemoveItem();
        
        /// <summary>
        /// Vérifie si un objet peut être ajouté à l'inventaire
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool CanAdd(IObject item);
    }
}