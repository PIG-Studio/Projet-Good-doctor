using UnityEngine;

public class PNJ 
{
        public Vector2 Position { get; private set; }
        public string Name { get; private set; }
        
        public PNJ(Vector2 position, string name)
        {
            Position = position;
            Name = name;
        }
    }