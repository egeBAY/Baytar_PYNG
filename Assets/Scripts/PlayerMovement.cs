using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashDistance = 5f; // The distance the character will dash
    public float dashDuration = 0.5f; // The duration of the dash
    public KeyCode dashKey = KeyCode.Space; // The key to press for dashing
    
    private bool isDashing = false; // Whether the character is currently dashing or not
 
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Move the player
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector2 moveDir = new Vector2(x, y).normalized;
        rb.velocity = moveDir * moveSpeed;
        // Check if the dash key is pressed and the character is not already dashing
        if (Input.GetKeyDown(dashKey) && !isDashing)
        {
            StartCoroutine(Dash());
        }   
    }
        private IEnumerator Dash()
    {
        isDashing = true;
        
        // Get the direction the character is facing
        Vector2 direction = transform.right;
        
        // Calculate the destination position
        Vector2 destination = (Vector2)transform.position + direction * dashDistance;
        
        // Calculate the duration of the dash
        float duration = dashDuration * dashDistance / Vector2.Distance(transform.position, destination);
        
        // Move the character towards the destination position
        while (Vector2.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector2.Lerp(transform.position, destination, Time.deltaTime / duration);
            yield return null;
        }
        
        isDashing = false;
    }
}

