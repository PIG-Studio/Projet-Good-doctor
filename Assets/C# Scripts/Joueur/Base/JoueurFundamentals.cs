using System;
using Desks;
using Exceptions;
using GameCore.Variables;
using Super.Interfaces.Entites;
using Super.Interfaces.GameObjects;
using Super.Interfaces.Joueur;
using TypeExpand.EDesk;
using Unity.Netcode;

namespace Joueur.Base
{
    public class JoueurFundamentals : NetworkBehaviour, IHasHp, IJoueur, IConditionAffichage
    {
        public uint Pv { get; protected set; }
        public uint Money { get; protected set; }
        public int Reputation { get; protected set; }
        public uint BureauActuel { get; protected set; }
        public Func<bool> ConditionAffichage { get; } = () => true;
        
        public NetworkVariable<UnityEngine.Vector2> Position { get; protected set; } = new(writePerm: NetworkVariableWritePermission.Server);

        private void Start()
        {
            AssignerBureauLibreServerRpc();
        }

        
        private void Update()
        {
            if (IsOwner)
            {
                UpdatePositionServerRpc(transform.position);
            }
            
        }
        [ServerRpc]
        void UpdatePositionServerRpc(UnityEngine.Vector2 position)
        {
            Position.Value = position;
        }

        [ServerRpc(RequireOwnership = false)]
        public void AssignerBureauLibreServerRpc()
        {
            uint indexDesk = Variable.AllDesks.TrouverBureauLibreServerRpc();
            Desk desk = Variable.AllDesks[indexDesk];
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