using Unity.Netcode;
using UnityEngine;
using UnityEngine.AI;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        protected abstract Sprite Skin { get; set; }
        public abstract string Name { get; protected set; }
        public abstract Vector2 Position { get; protected set; }
        
    }
}