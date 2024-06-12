using Interfaces.Entites;
using UnityEngine;

namespace Interfaces.Destination
{
    public interface IDestination
    {
        /// <summary>
        /// Capacité de la destination.
        /// </summary>
        public uint Capacite { get; }
        
        /// <summary>
        /// Indique si la destination est pleine.
        /// </summary>
        public bool IsFull { get; }
        
        /// <summary>
        /// Nombre d'entités présentes dans la destination.
        /// </summary>
        public uint NbEntites { get; }

        /// <summary>
        /// Identifiant de la destination.
        /// </summary>
        public uint DestId { get; }
        
        /// <summary>
        /// Position d'arrivée des entités à la destination.
        /// </summary>
        public Vector2 PtArrivee { get; set; }
        
        /// <summary>
        /// Positions d'attente des entités à la destination.
        /// </summary>
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
    }
}