using System.Collections.Generic;
using Desks;
using Exceptions;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using UnityEngine;

namespace Destinations.Implementation
{
    /// <summary>
    /// Classe représentant une destination de bureau
    /// </summary>
    public class DeskDestination : IDeskDestination
    {
        public uint Capacite { get; }
        public bool IsFull { get; private set; }
        public uint NbEntites { get; private set; }
        public uint DestId { get; }
        
        /// <summary>
        /// Position d'arrivée des entités à la destination
        /// </summary>
        public Vector2 PtArrivee { get; set; }
    
        /// <summary>
        /// Points d'attente des entités avant d'entrer dans la destination
        /// </summary>
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
            DestId = listId;
        }
        
        
        /// <summary>
        /// Méthode pour ajouter une entité à la destination
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="LogicException"></exception>
        public void Add(ICanGoInDesk entity)
        {
            Debug.Log("Adding entity "+ (NbEntites+1) +" to desk destination");
            if (IsFull) throw new LogicException("Destination pleine, impossible d'ajouter une entité, il faut vérifier si la capacité avant (cote patient)");

            for (int i = 0; i < PtAttente.Length; i++)
            {
                if (PtAttente[i].occupe) continue;
                PtAttente[i].occupe = true;
                PtAttente[i].occupant = entity;
                entity.Siege = (uint)i;
                DeskQueue.Enqueue(entity);
                NbEntites++;
                IsFull = NbEntites == Capacite;
                entity.StartWaitingServerRpc();
                break;
            }
        }

        
        /// <summary>
        /// Méthode pour retirer une entité de la destination
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