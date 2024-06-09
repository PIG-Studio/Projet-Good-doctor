using Interfaces.Entites;
using UnityEngine;

namespace Interfaces.Destination
{
    public interface IDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; }
        public uint NbEntites { get; }
        public uint DeskId { get; }
        
        public Vector2 PtArrivee { get; set; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
    }
}