using Exceptions;
using GameCore.Variables;
using Super.Interfaces.Destination;
using Super.Interfaces.Entites;
using TypeExpand.Int;
using Unity.Netcode;
using UnityEngine;

namespace PNJ.Mobile.CanAccessDest
{
    public class PnjCanGoInDest : PnjMobile, ICanGoInDestination
    {
        public IDestination Destination { get; protected set; }
        public NetworkVariable<bool> EnAttente { get; protected set; } = new(writePerm: NetworkVariableWritePermission.Server);
        public uint Siege { get; set; }
        
        protected new void Start()
        {
            base.Start();
            
            if (NetworkManager.Singleton.IsHost)
            {
                EnAttente.Value = false;
                ChooseDestinationServerRpc();
            }
        }
        
        [ServerRpc]
        public void ChooseDestinationServerRpc()
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
        [ServerRpc]
        public void StartWaitingServerRpc()
        {
            Navigation.SetDestination(Destination.PtAttente[Siege].coordonees);
            EnAttente.Value = true;
            Debug.Log("Patient commence a attendre");
            StartWaitingClientRpc();
        }
        [ClientRpc]
        public void StartWaitingClientRpc()
        {
            Debug.Log("Patient commence a attendre");
        }

        [ServerRpc]
        public void EndWaitingServerRpc()
        {
            Navigation.SetDestination(Destination.PtArrivee);
            EnAttente.Value = false;
            EndWaitingClientRpc();
            Debug.Log("Patient arrete d attendre");
        }
        [ClientRpc]
        public void EndWaitingClientRpc()
        {
            Debug.Log("Patient arrete d attendre");
        }
    }
}