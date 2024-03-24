using System;
using UnityEngine;
using static GameCore.Constantes;

namespace PlayerController
{
    /// <summary>
    /// Base pour les classes de contrôle des movements des joueurs
    /// </summary>
    public class PlayerController_Base : MonoBehaviour
    {
        public int smoothingFactor = 1;
        private float _currentInputH;
        private float _currentInputV;
        private Rigidbody2D _rb; // Reference to the Rigidbody2D component
        private Animator _anims;
        public GameObject vcam;

        public void StartBase(GameObject vcamIn, GameObject player)
        {
            _rb = player.GetComponent<Rigidbody2D>();
            _anims = player.GetComponent<Animator>();
            vcam = vcamIn;
            _currentInputH = 0f;
            _currentInputV = 0f;
        }

        /// <summary>
        /// Met à jour la position de l'objet
        /// </summary>
        public void UpdateBase()
        {
            // On recupere les entrees de l'utilisateur
            float rawVerticalInput = Input.GetAxis("Vertical") * MoveSpeed;
            float rawHorizontalInput = Input.GetAxis("Horizontal") * MoveSpeed;

            // Smooth the input to reduce jitter Formule chelou mais qui marche je crois, donne un niveau un peu graduel au movement
            float smoothedHorizontalInput = Mathf.Lerp(_currentInputH, rawHorizontalInput, 10);
            float smoothedVerticalInput = Mathf.Lerp(_currentInputV, rawVerticalInput, 10);

            /*// On limite la vitesse de deplacement sur chacun des axes
            if (smoothedVerticalInput > maxSpeed)
                smoothedVerticalInput = maxSpeed;
            if (smoothedHorizontalInput > maxSpeed)
                smoothedHorizontalInput = maxSpeed;
            if (smoothedVerticalInput < -maxSpeed)
                smoothedVerticalInput = -maxSpeed;
            if (smoothedHorizontalInput < -maxSpeed)
                smoothedHorizontalInput = -maxSpeed;TODO : remove if useless*/
            
            // On actualise l'animation en fonction de la direction
            if (smoothedVerticalInput < 0)
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", true);
            }
            else if (smoothedVerticalInput > 0)
            {
                _anims.SetBool("MovingUp", true);
                _anims.SetBool("MovingDown", false);
            }
            else
            {
                _anims.SetBool("MovingUp", false);
                _anims.SetBool("MovingDown", false);
            }

            if (smoothedHorizontalInput > 0)
            {
                _anims.SetBool("MovingRight", true);
                _anims.SetBool("MovingLeft", false);
            }
            else if (smoothedHorizontalInput < 0)
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
            float vTot = Math.Abs(smoothedHorizontalInput) + Math.Abs(smoothedVerticalInput);
            float coeffR = MaxSpeed / vTot;
            if (vTot > MaxSpeed)
            {
                smoothedHorizontalInput *= coeffR;
                smoothedVerticalInput *= coeffR;
            }

            // Store the smoothed input for the next frame
            _currentInputH = smoothedHorizontalInput;
            _currentInputV = smoothedVerticalInput;
            
            Vector2 movement = new Vector2(smoothedHorizontalInput, smoothedVerticalInput);
            Vector2 newPosition = _rb.position + movement;
            _rb.MovePosition(newPosition);
        }
    }
}