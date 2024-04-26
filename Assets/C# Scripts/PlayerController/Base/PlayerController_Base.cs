using System;
using UnityEngine;
using static GameCore.GameVAR.Constantes;

namespace PlayerController
{
    /// <summary>
    /// Base pour les classes de contrôle des movements des joueurs
    /// </summary>
    public class PlayerController_Base : MonoBehaviour
    {
        private Rigidbody2D _rb; // Reference to the Rigidbody2D component
        private Animator _anims;
        public GameObject vcam;

        public void StartBase(GameObject vcamIn, GameObject player)
        {
            _rb = player.GetComponent<Rigidbody2D>();
            _anims = player.GetComponent<Animator>();
            vcam = vcamIn;
        }

        /// <summary>
        /// Met à jour la position de l'objet
        /// </summary>
        public void UpdateBase()
        {
            // On recupere les entrees de l'utilisateur
            float verticalInput = Input.GetAxis("Vertical") * MoveSpeed;
            float horizontalInput = Input.GetAxis("Horizontal") * MoveSpeed;

            // On actualise l'animation en fonction de la direction
            if (verticalInput < 0)
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", true);
            }
            else if (verticalInput > 0)
            {
                _anims.SetBool("MovingUp", true);
                _anims.SetBool("MovingDown", false);
            }
            else
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", false);
            }

            if (horizontalInput > 0)
            {
                _anims.SetBool("MovingRight", true);
                _anims.SetBool("MovingLeft", false);
            }
            else if (horizontalInput < 0)
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", true);
            }
            else
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", false);
            }


            // On limite la vitesse de deplacement
            float vTot = (float)(Math.Sqrt(Math.Pow(horizontalInput, 2) + Math.Pow(verticalInput, 2)));
            float coeffR = (MaxSpeed / vTot);
            if (vTot > MaxSpeed)
            {
                horizontalInput *= coeffR;
                verticalInput *= coeffR;
            }
            
            // On cree un vecteur de deplacement
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            
            Debug.Log($"V ABS = {Math.Sqrt(Math.Pow(horizontalInput, 2) + Math.Pow(verticalInput, 2))}");
            
            // On deplace l'objet
            Vector2 newPosition = _rb.position + movement;
            _rb.MovePosition(newPosition);
        }
    }
}