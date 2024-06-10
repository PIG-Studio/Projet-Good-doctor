using System.Collections.Generic;
using Desks;
using Exceptions;
using Interfaces.Destination;
using Interfaces.Entites;
using UnityEngine;

namespace Destinations.Implementation
{
    public class DeskDestination : IDeskDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; private set; }
        public uint NbEntites { get; private set; }
        public uint DeskId { get; }
        
        public Vector2 PtArrivee { get; set; }
        public (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] PtAttente { get; }
        
        public Desk Bureau { get; }
        public Queue<ICanGoInDesk> DeskQueue { get; set; }

        public DeskDestination(uint capacite, Vector2 ptArrivee, (bool occupe, Vector2 coordonees, ICanGoInDestination occupant)[] ptAttente, Desk bureau, uint listId)
        {
            Capacite = capacite;
            PtArrivee = ptArrivee;
            PtAttente = ptAttente;
            IsFull = false;
            NbEntites = 0;
            Bureau = bureau;
            DeskQueue = new Queue<ICanGoInDesk>();
            DeskId = listId;
        }
        
        public void Add(ICanGoInDesk entity)
        {
            Debug.Log("Adding entity "+ (NbEntites+1) +" to desk destination");
            if (IsFull) throw new LogicException("Destination pleine, impossible d'ajouter une entité, il faut verifier si la capacite avant (cote patient)");

            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (PtAttente[i].occupe) continue;
                PtAttente[i].occupe = true;
                PtAttente[i].occupant = entity;
                entity.Siege = (uint)i;
                DeskQueue.Enqueue(entity);
                NbEntites++;
                IsFull = NbEntites == Capacite;
                entity.StartWaiting();
                break;
            }
        }

        
        /// <summary>
        /// A FINIR TODO
        /// </summary>
        /// <returns></returns>
        /// <exception cref="LogicException"></exception>
        public ICanGoInDesk Pop()
        {
            if (NbEntites == 0) throw new LogicException("Destination vide");

            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (!PtAttente[i].occupe) continue;
                PtAttente[i].occupe = false;
                PtAttente[i].occupant = null;
                NbEntites--;
                IsFull = false;
                break;
            }

            return DeskQueue.Dequeue();
        }
        
    }
}