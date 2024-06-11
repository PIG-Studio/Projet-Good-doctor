using Unity.Netcode;
using UnityEngine;
using GameCore.Variables;

namespace Network.Sync.Variables
{
    public class NetworkJoueur : NetworkBehaviour
    {
        // Variables pour stocker les données du joueur qui seront synchronisées sur le réseau
        private readonly NetworkVariable<Vector2> _pos = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _isOnMapScene = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingUp = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingDown = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingLeft = new(writePerm: NetworkVariableWritePermission.Owner);
        private readonly NetworkVariable<bool> _movingRight = new(writePerm: NetworkVariableWritePermission.Owner);
       
        // Références aux composants du joueur
        public SpriteRenderer sprite;
        public Animator anims;
        
        // Hash des paramètres d'animation de déplacement pour l'Animator
        private static readonly int MovingDown = Animator.StringToHash("MovingDown");
        private static readonly int MovingRight = Animator.StringToHash("MovingRight");
        private static readonly int MovingLeft = Animator.StringToHash("MovingLeft");
        private static readonly int MovingUp = Animator.StringToHash("MovingUp");

        void Update()
        {
            if (IsOwner) // Vérifie si le joueur est propriétaire du réseau
            {
                // Si le joueur est sur la scène de la carte de l'hôpital
                if (Variable.SceneNameCurrent == "MapHospital")
                {
                    // Met à jour les données du joueur pour les synchroniser sur le réseau
                    _pos.Value = transform.position;
                    _isOnMapScene.Value = true;
                    sprite.enabled = true;
                    _movingUp.Value = anims.GetBool(MovingUp);
                    _movingDown.Value = anims.GetBool(MovingDown);
                    _movingLeft.Value = anims.GetBool(MovingLeft);
                    _movingRight.Value = anims.GetBool(MovingRight);
                }
                else
                { // Désactive le rendu du sprite si le joueur n'est pas sur la scène de la carte de l'hôpital
                    _isOnMapScene.Value = false;
                    sprite.enabled = false;
                }
            }
            else
            { 
                // Si le joueur n'est pas propriétaire du réseau, synchronise les données du joueur à partir du réseau
                sprite.enabled = _isOnMapScene.Value;
                if (sprite.enabled)
                {
                    transform.position = _pos.Value;
                    anims.SetBool(MovingUp, _movingUp.Value);
                    anims.SetBool(MovingDown, _movingDown.Value);
                    anims.SetBool(MovingLeft, _movingLeft.Value);
                    anims.SetBool(MovingRight, _movingRight.Value);
                }
            }

        }
    }
}