using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public int smoothingFactor = 1;
    private float currentInputH = 0f;
    private float currentInputV = 0f;
    public float maxSpeed = 0.15f;
    private Rigidbody2D rb;           // Reference to the Rigidbody2D component
    PolygonCollider2D characterCollider; // Reference to the character's PolygonCollider2D component
    public Animator anims;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        characterCollider = GetComponent<PolygonCollider2D>(); // Get the character's PolygonCollider2D
    }

    private void Update()
    {
        // Get the raw horizontal input
        float rawHorizontalInput = Input.GetAxis("Horizontal");
        float rawVerticalInput = Input.GetAxis("Vertical");
        rawVerticalInput *= moveSpeed;
        rawHorizontalInput *= moveSpeed;
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
            anims.SetBool("MovingDown", true);
        else 
            anims.SetBool("MovingDown", false);
        if (smoothedVerticalInput > 0)
            anims.SetBool("MovingUp", true);
        else 
            anims.SetBool("MovingUp", false);
        
        if (smoothedHorizontalInput > 0)
            anims.SetBool("MovingRight", true);
        else 
            anims.SetBool("MovingRight", false);

        if (smoothedHorizontalInput < 0)
            anims.SetBool("MovingLeft", true);
        else
            anims.SetBool("MovingLeft", false);
        
        // Move the character horizontally based on the smoothed input
        Vector2 movement = new Vector2(smoothedHorizontalInput , smoothedVerticalInput);
        Vector2 newPosition = rb.position + movement ;
        rb.MovePosition(newPosition);
    }

    
    
    

    bool IsColliding(Vector2 newPosition)
    {
        PolygonCollider2D characterCollider = GetComponent<PolygonCollider2D>(); // Get the character's PolygonCollider2D

        // Create a temporary collider for overlap check
        Collider2D[] results = new Collider2D[1];
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.layerMask = LayerMask.GetMask("Walls");

        // Check for overlap with obstacles using Physics2D.OverlapCollider
        int count = characterCollider.OverlapCollider(contactFilter, results);

        // Check if there is a collision
        return count > 0;
    }

}
