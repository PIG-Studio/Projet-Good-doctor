using Interfaces.Entites;
using UnityEngine;

namespace Interfaces.Destination
{
    public interface IDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; }
        public uint NbEntites { get; }
        
        public Vector2 PtArrivee { get; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
        
        public uint Add(ICanGoInDestination entity);
        public void Pop(uint siege);
        
        
        
    }
}