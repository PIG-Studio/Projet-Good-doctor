using Exceptions;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;

namespace Destinations.Implementation
{
    public class NormalDestination : INormalDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; private set; }
        public uint NbEntites { get; private set; }
        
        public Vector2 PtArrivee { get; set; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
        
        public NormalDestination(uint capacite, Vector2 ptArrivee, (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] ptAttente)
        {
            Capacite = capacite;
            PtArrivee = ptArrivee;
            PtAttente = ptAttente;
            IsFull = false;
            NbEntites = 0;
        }
        
        public uint Add(ICanGoInDestination entity)
        {
            if (IsFull) throw new LogicException("Destination pleine, impossible d'ajouter une entité, il faut verifier si la capacite avant (cote patient)");

            uint siege = 0;
            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (PtAttente[i].occupe) continue;
                PtAttente[i].occupe = true;
                PtAttente[i].occupant = entity;
                entity.StartWaiting();
                siege = (uint)i;
                break;
            }
            
            NbEntites++;
            IsFull = NbEntites == Capacite;

            return siege;
        }
        
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