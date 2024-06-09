using UnityEngine;

namespace Super.Abstract
{
    public abstract class APnj: ARender
    {
        protected abstract Sprite Skin { get; set; } 
        public abstract string Name { get; protected set; }
        protected abstract Vector2 Position { get; set; }
        public abstract string Phrase { get; protected set; }
        
    }
}