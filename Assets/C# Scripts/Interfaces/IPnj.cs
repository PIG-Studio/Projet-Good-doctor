using UnityEngine;

namespace Interfaces
{
    public interface IPnj
    {
        public Sprite Skin { get; set; }
        
        public string Name { get; set; }
        
        public Vector2 Position { get; set; }
    }
}