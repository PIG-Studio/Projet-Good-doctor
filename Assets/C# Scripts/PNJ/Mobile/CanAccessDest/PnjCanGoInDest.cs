using System;
using Exceptions;
using GameCore.Variables;
using Interfaces.Destination;
using Interfaces.Entites;
using TypeExpand.Int;

namespace PNJ.Mobile.CanAccessDest
{
    public class PnjCanGoInDest : PnjMobile, ICanGoInDestination
    {
        public IDestination Destination { get; protected set; }
        public bool EnAttente { get; protected set; }
        public uint Siege { get; set; }
        
        protected new void Start()
        {
            base.Start();
            EnAttente = false;
            
            if (Unity.Netcode.NetworkManager.Singleton.IsHost)
            {
                ChooseDestination();
            }
        }
        
        public void ChooseDestination()
        {
            uint i = 0;
            while (true)
            {
                Destination = Variable.AllDestinations[Variable.AllDestinations.Count.RandomInt()];//RINT NE PREND PAS LA BORNE SUP, Y A 2 DEST AU MM ENDROIT CAR BUREAUX HARDCODED
                
                i++;
                if (i > 100) { throw new LogicException("Aucune destination disponible"); }

                if (Destination.IsFull) continue;
                
                Navigation.SetDestination(Destination.PtArrivee);
                break;
            }
        }
        
        public void StartWaiting()
        {
            Navigation.SetDestination(Destination.PtAttente[Siege].coordonees);
            EnAttente = true;
        }
        
        public void EndWaiting()
        {
            throw new NotImplementedException();
        }
        
    }
}