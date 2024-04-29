using UnityEngine;

namespace PNJ
{
    public class Pnj
    {
        public Vector2 Position { get; private set; }
        public string Name { get; private set; }

        public Pnj(Vector2 position, string name)
        {
            Position = position;
            Name = name;
        }
    }
}