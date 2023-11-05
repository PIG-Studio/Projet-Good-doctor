using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float smoothingFactor = 0f;
    private float currentInputH = 0f;
    private float currentInputV = 0f;
    private float maxSpeed = 0.05f;
    private Rigidbody2D rb;           // Reference to the Rigidbody2D component
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the raw horizontal input
        float rawHorizontalInput = Input.GetAxis("Horizontal");
        float rawVerticalInput = Input.GetAxis("Vertical");

        // Smooth the input to reduce jitter
        float smoothedHorizontalInput = Mathf.Lerp(currentInputH, rawHorizontalInput, smoothingFactor * Time.fixedDeltaTime);
        float smoothedVerticalInput = Mathf.Lerp(currentInputV, rawVerticalInput, smoothingFactor * Time.fixedDeltaTime);

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

// Perform collision detection
        RaycastHit2D hitH = Physics2D.Raycast(rb.position, movementH, 1.25f, LayerMask.GetMask("Walls"));
        RaycastHit2D hitV = Physics2D.Raycast(rb.position, movementV, 1.25f, LayerMask.GetMask("Walls"));
        if (hitH.collider != null)
        {
            smoothedHorizontalInput = 0;
        }
        if (hitV.collider != null)
        {
            smoothedVerticalInput = 0;
        }
        
        currentInputH = smoothedHorizontalInput;
        currentInputV = smoothedVerticalInput;

        // Move the character horizontally based on the smoothed input
        Vector3 moveDirection = new Vector3(smoothedHorizontalInput, smoothedVerticalInput, 0);
        
        transform.Translate(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
