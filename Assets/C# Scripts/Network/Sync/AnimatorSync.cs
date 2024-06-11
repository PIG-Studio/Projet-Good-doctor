using System;
using Super.Interfaces.GameObjects;
using Unity.Netcode;
using UnityEngine;

namespace Network.Sync
{
    public class AnimatorSync : NetworkBehaviour
    {
        // Variables pour stocker les données du joueur qui seront synchronisées sur le réseau
        private readonly NetworkVariable<bool> _movingUp = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingDown = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingLeft = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingRight = new(writePerm: NetworkVariableWritePermission.Owner);
       
        // Références aux composants du joueur
        public Animator anims;
        private Func<bool> ConditionAffichage { get; set; }
        
        // Hash des paramètres d'animation de déplacement pour l'Animator
        private static readonly int MovingDown = Animator.StringToHash("MovingDown");
        private static readonly int MovingRight = Animator.StringToHash("MovingRight");
        private static readonly int MovingLeft = Animator.StringToHash("MovingLeft");
        private static readonly int MovingUp = Animator.StringToHash("MovingUp");

        private void Start()
        {
            anims = GetComponent<Animator>();
            ConditionAffichage = GetComponent<IConditionAffichage>().ConditionAffichage;
        }

        void Update()
        {
            if (IsOwner) // Vérifie si le joueur est propriétaire du réseau
            {
                // Si le joueur est sur la scène de la carte de l'hôpital
                if (ConditionAffichage())
                {
                    // Met à jour les données du joueur pour les synchroniser sur le réseau
                    _movingUp.Value = anims.GetBool(MovingUp);
                    _movingDown.Value = anims.GetBool(MovingDown);
                    _movingLeft.Value = anims.GetBool(MovingLeft);
                    _movingRight.Value = anims.GetBool(MovingRight);
                }
            }
            else
            { 
                // Si le joueur n'est pas propriétaire du réseau, synchronise les données du joueur à partir du réseau
                if (ConditionAffichage())
                {
                    anims.SetBool(MovingUp, _movingUp.Value);
                    anims.SetBool(MovingDown, _movingDown.Value);
                    anims.SetBool(MovingLeft, _movingLeft.Value);
                    anims.SetBool(MovingRight, _movingRight.Value);
                }
            }

        }
    }
}