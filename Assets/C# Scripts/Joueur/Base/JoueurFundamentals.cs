using System;
using Desks;
using GameCore.Variables;
using Inventories.Player;
using Super.Interfaces.Entites;
using Super.Interfaces.GameObjects;
using Super.Interfaces.Joueur;
using TypeExpand.EDesk;
using Unity.Netcode;
using UnityEngine;

namespace Joueur.Base
{
    public class JoueurFundamentals : NetworkBehaviour, IHasHp, IJoueur, IConditionAffichage
    {
        public uint Pv { get; set; }
        public uint Money { get; set; }
        public int Reputation { get; set; }
        public uint? BureauActuel { get; protected set; }
        public PlayerInventory Inventory { get; set; }
        public Func<bool> ConditionAffichage { get; } = () => true;
        private NetworkVariable<Vector2> Position { get; } = new(writePerm: NetworkVariableWritePermission.Server);


        private void Start()
        {
            if (IsOwner)
            {
                AssignerBureauLibreServerRpc();
            }
            
            Inventory = transform.Find("InventoryManager").GetComponent<PlayerInventory>();
            Inventory.Start();
            Inventory.Update();
            Money = 100;
            Reputation = 60;
            Pv = 50;
        }

        
        private void Update()
        {
            if (IsOwner)
            {
                UpdatePositionServerRpc(transform.position);
            }
            else
            {
                transform.position = Position.Value;
            }
            
        }
        [ServerRpc]
        public void UpdatePositionServerRpc(Vector2 position)
        {
            Position.Value = position;
        }

        [ServerRpc]
        public void AssignerBureauLibreServerRpc()
        {
            uint indexDesk = Variable.AllDesks.TrouverBureauLibreServerRpc();
            Desk desk = Variable.AllDesks[indexDesk];
            if (desk == null)
            {
                Debug.LogWarning("Aucun bureau n'a été trouvé.");
                BureauActuel = null;
                return;
            }
            desk!.Responsable = this;
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