using System;
using Super.Abstract;
using UnityEngine;
using TypeExpand.Animator;
using Unity.Collections;
using Unity.Netcode;

namespace PNJ.Base
{
    public class Pnj : APnj
    {
        public override NetworkVariable<FixedString64Bytes> Name { get; protected set; }= new(writePerm: NetworkVariableWritePermission.Owner);
        public override string Phrase { get; protected set; }
        protected override Sprite Skin { get; set; }
        protected override Vector2 Position { get; set; }
        private Vector2 LastPosition { get; set; }
        private Vector2 Velocity { get; set; }
        

        protected override Animator Anims { get; set; }
        protected override SpriteRenderer Sprite { get; set; }
        
        protected Func<bool> ConditionAffichage { get; set; }
        
        

        public void Start()
        {
            Anims = gameObject.GetComponent<Animator>(); 
            Sprite = gameObject.GetComponent<SpriteRenderer>();
            Position = transform.position;
            if (!NetworkManager.Singleton.IsHost) return;
            NetworkObject instanceNetworkObject = gameObject.GetComponent<NetworkObject>();
            instanceNetworkObject.Spawn();
        }

        public void Update()
        { 
            if (ConditionAffichage())
            {
                Sprite.enabled = true;
                LastPosition = Position;
                Position = transform.position;
                Velocity = Position - LastPosition;
                Anims.UpdateAnim(Velocity);
            }
            else 
            { Sprite.enabled = false; }

            // Moved to patient
            /*if (Patient.EnAttente || AgentComp.remainingDistance > 2f) return;
            
            if (Destination.IsFull)
            {
                Debug.Log("Destination pleine, recherche d'une autre destination");
                Patient.ChooseDestination();
                return;
            }
            
            switch (Destination)
            {
                case IDeskDestination deskDestination:
                    deskDestination.Add(Patient);
                    break;
                case INormalDestination normalDestination:
                    normalDestination.Add(Patient);
                    break;
            }*/
        }
    }
}