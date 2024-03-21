using System;
using UnityEngine;

namespace PlayerController_Base
{
    public class PlayerController : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public int smoothingFactor = 1;
        private float currentInputH;
        private float currentInputV;
        public float maxSpeed = 0.15f;
        private Rigidbody2D rb;           // Reference to the Rigidbody2D component
        public Animator anims;
        public GameObject vcam;
        
        public void StartBase(GameObject vcamIn, GameObject player)
        {
            rb = player.GetComponent<Rigidbody2D>();
            anims = player.GetComponent<Animator>();
            vcam = vcamIn;
            currentInputH = 0f;
            currentInputV = 0f;
        }

        public void UpdateBase()
        {
            float rawVerticalInput = Input.GetAxis("Vertical") * moveSpeed;
            float rawHorizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

            // Smooth the input to reduce jitter
            float smoothedHorizontalInput = Mathf.Lerp(currentInputH, rawHorizontalInput, 10);
            float smoothedVerticalInput = Mathf.Lerp(currentInputV, rawVerticalInput, 10);


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

            currentInputH = smoothedHorizontalInput;
            currentInputV = smoothedVerticalInput;

            if (smoothedVerticalInput < 0)
            {
                anims.SetBool("MovingUp", false);
                anims.SetBool("MovingDown", true);
            }
            else if (smoothedVerticalInput > 0)
            {
                anims.SetBool("MovingUp", true);
                anims.SetBool("MovingDown", false);
            }
            else
            {
                anims.SetBool("MovingUp", false);
                anims.SetBool("MovingDown", false);
            }

            if (smoothedHorizontalInput > 0)
            {
                anims.SetBool("MovingRight", true);
                anims.SetBool("MovingLeft", false);
            }
            else if(smoothedHorizontalInput < 0)
            {
                anims.SetBool("MovingRight", false);
                anims.SetBool("MovingLeft", true);
            }
            else
            {
                anims.SetBool("MovingRight", false);
                anims.SetBool("MovingLeft", false);
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
            Vector2 newPosition = rb.position + movement;
            rb.MovePosition(newPosition);
        }
    }
}