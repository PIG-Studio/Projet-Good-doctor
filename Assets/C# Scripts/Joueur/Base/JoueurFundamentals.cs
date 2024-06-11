using System;
using Desks;
using Exceptions;
using GameCore.Variables;
using JetBrains.Annotations;
using Super.Interfaces.Entites;
using Super.Interfaces.Joueur;
using TypeExpand.EDesk;
using Unity.Netcode;

namespace Joueur.Base
{
    public class JoueurFundamentals : NetworkBehaviour, IHasHp, IJoueur
    {
        public uint Pv { get; protected set; }
        public uint Money { get; protected set; }
        public int Reputation { get; protected set; }
        public uint BureauActuel { get; protected set; }

        private void Start()
        {
            AssignerBureauLibreServerRpc();
        }
        
        [ServerRpc]
        public void AssignerBureauLibreServerRpc()
        {
            uint indexDesk = Variable.Desks.TrouverBureauLibreServerRpc();
            Desk desk = Variable.Desks[indexDesk];
            if (desk == null)
            {
                throw new LogicException("Aucun bureau n'a été trouvé.");
            }
            desk.Responsable = this;
            BureauActuel = indexDesk;
            AssignerBureauLibreClientRpc(indexDesk);
        }
        [ClientRpc]
        public void AssignerBureauLibreClientRpc(uint indexDesk)
        {
            BureauActuel = indexDesk;
        }
    }
}