using System;
using TypeExpand.Animator;
using Inventories;
          
using UnityEngine;
using GameCore.Constantes;
using Unity.Netcode;

namespace PlayerController.Base
{
    /// <summary>
    /// Base pour les classes de contrôle des movements des joueurs
    /// </summary>
    public class PlayerController : NetworkBehaviour
    {
        private Rigidbody2D _rb; // Reference to the Rigidbody2D component
        private Animator _anims;
        public GameObject vcam;
        protected Inventory PlayerInventory { get; set; }

        public void Start()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
            _anims = gameObject.GetComponent<Animator>();
        }

        /// <summary>
        /// Met à jour la position de l'objet
        /// </summary>
        public void Update()
        {
            // On recupere les entrees de l'utilisateur
            float verticalInput = Input.GetAxis("Vertical") * Constante.MoveSpeed;
            float horizontalInput = Input.GetAxis("Horizontal") * Constante.MoveSpeed;

            // On actualise l'animation en fonction de la direction
            _anims.UpdateAnim(new Vector2(horizontalInput, verticalInput));


            // On limite la vitesse de deplacement
            float vTot = (float)(Math.Sqrt(Math.Pow(horizontalInput, 2) + Math.Pow(verticalInput, 2)));
            float coeffR = (Constante.MaxSpeed / vTot);
            if (vTot > Constante.MaxSpeed)
            {
                horizontalInput *= coeffR;
                verticalInput *= coeffR;
            }
            
            // On crée un vecteur de deplacement
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            
            //Debug.Log($"V ABS = {Math.Sqrt(Math.Pow(horizontalInput, 2) + Math.Pow(verticalInput, 2))}");
            
            // On déplace l'objet
            Vector2 newPosition = _rb.position + movement;
            _rb.MovePosition(newPosition);
        }
    }
}