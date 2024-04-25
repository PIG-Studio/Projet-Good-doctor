<<<<<<< HEAD
    using UnityEngine;

    public class PNJ
=======
    using C__Scripts.PNJ;
    using UnityEngine;

    public class PNJ 
>>>>>>> dev_Alex
    {
        public Vector2 Position { get; private set; }
        public string Name { get; private set; }
        
        public PNJ(Vector2 position, string name)
        {
            Position = position;
            Name = name;
        }
    }