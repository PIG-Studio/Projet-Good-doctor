using Exceptions;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using UnityEngine;

namespace Destinations.Implementation
{
    /// <summary>
    /// Classe représentant une destination normale
    /// </summary>
    public class NormalDestination : INormalDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; private set; }
        public uint NbEntites { get; private set; }
        public uint DestId { get; }
        
        public Vector2 PtArrivee { get; set; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
        
        public NormalDestination(uint capacite, Vector2 ptArrivee, (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] ptAttente, uint listId)
        {
            Capacite = capacite;
            PtArrivee = ptArrivee;
            PtAttente = ptAttente;
            IsFull = false;
            NbEntites = 0;
            DestId = listId;
            Debug.Log($"destination {DestId} initialisée ({Capacite})");
        }
        
        /// <summary>
        /// Méthode pour ajouter une entité à la destination
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="LogicException"></exception>
        public uint Add(ICanGoInDestination entity)
        {
            if (IsFull) throw new LogicException("Destination pleine, impossible d'ajouter une entité, il faut verifier si la capacite avant (cote patient)");

            uint siege = 0;
            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (PtAttente[i].occupe) continue;
                PtAttente[i].occupe = true;
                PtAttente[i].occupant = entity;
                entity.Siege = (uint)i;
                NbEntites++;
                IsFull = NbEntites == Capacite;
                entity.StartWaitingServerRpc();
                break;
            }
            NbEntites++;
            IsFull = NbEntites == Capacite;

            return siege;
        }
        
        /// <summary>
        /// Méthode pour retirer une entité de la destination
        /// </summary>
        /// <param name="siegeNb"></param>
        /// <exception cref="LogicException"></exception>
        public void Pop(uint siegeNb)
        {
            if (NbEntites == 0) throw new LogicException("Destination vide");

            PtAttente[siegeNb].occupe = false;
            PtAttente[siegeNb].occupant = null;
            NbEntites--;
            IsFull = false;
        }
    }
}