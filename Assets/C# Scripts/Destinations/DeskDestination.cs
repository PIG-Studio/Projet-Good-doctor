using System.Collections.Generic;
using Desks;
using Exceptions;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;

namespace Destinations
{
    public class DeskDestination : IDeskDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; private set; }
        public uint NbEntites { get; private set; }
        
        public Vector2 PtArrivee { get; set; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
        
        public Desk Bureau { get; }
        public Queue<ICanGoInDesk> DeskQueue { get; set; }

        public DeskDestination(uint capacite, Vector2 ptArrivee, (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] ptAttente, Desk bureau)
        {
            Capacite = capacite;
            PtArrivee = ptArrivee;
            PtAttente = ptAttente;
            IsFull = false;
            NbEntites = 0;
            Bureau = bureau;
            DeskQueue = new Queue<ICanGoInDesk>();
        }
        
        public void Add(ICanGoInDesk entity)
        {
            if (IsFull) throw new LogicException("Destination pleine, impossible d'ajouter une entité, il faut verifier si la capacite avant (cote patient)");

            uint siege = 0;
            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (PtAttente[i].occupe) continue;
                PtAttente[i].occupe = true;
                PtAttente[i].occupant = entity;
                entity.Siege = (uint)i;
                entity.StartWaiting();
                break;
            }
            
            DeskQueue.Enqueue(entity);
            NbEntites++;
            IsFull = NbEntites == Capacite;
        }

        public ICanGoInDesk Pop()
        {
            if (NbEntites == 0) throw new LogicException("Destination vide");

            PtAttente[0].occupe = false;
            PtAttente[0].occupant = null;
            NbEntites--;
            IsFull = false;

            return DeskQueue.Dequeue();
        }
        
    }
}