using GameCore.Variables;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;
using Component = System.ComponentModel.Component;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        /// <summary>
        /// Le sprite du Pnj
        /// </summary>
        protected abstract uint _skin { get; set; }

        protected abstract uint Skin { get; set; }
        public abstract NetworkVariable<FixedString64Bytes> Name { get; protected set; }
        protected abstract NetworkVariable<Vector2> Position { get; set; }
        public abstract string Phrase { get; protected set; }
        
    }
}