using GameCore.Variables;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        /// <summary>
        /// Le sprite du Pnj
        /// </summary>
        private uint _skin;

        protected uint Skin 
        {
            get
            {
                return _skin;
            }
            set
            {
                Anims = Variable.PnjSkin[value];
                _skin = value;
            } 
        }
        public abstract NetworkVariable<FixedString64Bytes> Name { get; protected set; }
        protected abstract NetworkVariable<Vector2> Position { get; set; }
        public abstract string Phrase { get; protected set; }
        
    }
}