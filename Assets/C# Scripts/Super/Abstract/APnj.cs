using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        protected abstract Sprite Skin { get; set; } 
        public abstract NetworkVariable<FixedString64Bytes> Name { get; protected set; }
        protected abstract NetworkVariable<Vector2> Position { get; set; }
        public abstract string Phrase { get; protected set; }
        
    }
}