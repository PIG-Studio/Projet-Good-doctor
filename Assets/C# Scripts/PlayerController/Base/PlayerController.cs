using System;
using UnityEngine;

namespace PlayerController_Base
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public int smoothingFactor = 1;
        private float _currentInputH;
        private float _currentInputV;
        public float maxSpeed = 0.15f;
        private Rigidbody2D _rb;           // Reference to the Rigidbody2D component
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

        public void UpdateBase()
        {
            float rawVerticalInput = Input.GetAxis("Vertical") * moveSpeed;
            float rawHorizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

            // Smooth the input to reduce jitter
            float smoothedHorizontalInput = Mathf.Lerp(_currentInputH, rawHorizontalInput, 10);
            float smoothedVerticalInput = Mathf.Lerp(_currentInputV, rawVerticalInput, 10);


            if (smoothedVerticalInput > maxSpeed)
                smoothedVerticalInput = maxSpeed;
            if (smoothedHorizontalInput > maxSpeed)
                smoothedHorizontalInput = maxSpeed;
            if (smoothedVerticalInput < -maxSpeed)
                smoothedVerticalInput = -maxSpeed;
            if (smoothedHorizontalInput < -maxSpeed)
                smoothedHorizontalInput = -maxSpeed;

            // Store the smoothed input for the next frame

            Vector2 movementH = new Vector2(smoothedHorizontalInput, 0);
            Vector2 movementV = new Vector2(0, smoothedVerticalInput);

            _currentInputH = smoothedHorizontalInput;
            _currentInputV = smoothedVerticalInput;

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
            else if(smoothedHorizontalInput < 0)
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", true);
            }
            else
            {
                _anims.SetBool("MovingRight", false);
                _anims.SetBool("MovingLeft", false);
            }
            

            // Move the character horizontally based on the smoothed input
            Vector2 movement = new Vector2(smoothedHorizontalInput, smoothedVerticalInput);
            float vTot = Math.Abs(movement.x) + Math.Abs(movement.y);
            float coefR = maxSpeed / vTot;
            if(vTot > maxSpeed)
            {
                movement.x *= coefR;
                movement.y *= coefR;
            }
            Vector2 newPosition = _rb.position + movement;
            _rb.MovePosition(newPosition);
        }
    }
}