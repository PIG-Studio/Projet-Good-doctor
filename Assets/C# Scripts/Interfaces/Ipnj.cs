namespace C__Scripts.PNJ
{
    using UnityEngine;
    using Interfaces;
    public interface Ipnj
    {
        public Sprite Skin { get; set; }
        
        public string Name { get; set; }
        
        public Vector2 Position { get; set; }
        public void Move();
    }
}