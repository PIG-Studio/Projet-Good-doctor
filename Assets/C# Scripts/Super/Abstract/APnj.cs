using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        /// <summary>
        /// Sprite du PNJ.
        /// </summary>
        protected abstract uint SkinVal { get; set; }
        protected abstract uint Skin { get; set; }
        
        /// <summary>
        /// Nom du PNJ.
        /// </summary>
        public abstract NetworkVariable<FixedString64Bytes> Name { get; protected set; }
        
        /// <summary>
        /// Position du PNJ dans l'environnement.
        /// </summary>
        protected abstract NetworkVariable<Vector2> Position { get; set; }
        /// <summary>
        /// Phrase associée au PNJ.
        /// </summary>
        public abstract string Phrase { get; protected set; } 
        
        protected Rigidbody2D Rb { get; set; }
        
    }
}