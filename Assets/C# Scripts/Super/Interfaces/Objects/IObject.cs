using UnityEngine;

namespace Interfaces.Objects
{
    public interface IObject
    {
        /// <summary>
        /// Le nom de l'objet
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// Le montant de l'objet
        /// </summary>
        uint Amount { get; set; }
        
        /// <summary>
        /// Le sprite de l'objet
        /// </summary>
        Sprite Image { get; set; }

        
    }
}