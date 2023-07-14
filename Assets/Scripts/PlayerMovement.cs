using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private bool canDash = true;
    private bool isDashing; // Whether the character is currently dashing or not
    public float dashDistance = 5f; // The distance the character will dash
    public float dashDuration = 1f; // The duration of the dash
    private float dashingCooldown = 1f;
    private KeyCode dashKey = KeyCode.Space; // The key to press for dashing

    private Vector3 movement;

    public Animator animator;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (isDashing) return;

        // Move the player
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * moveSpeed * Time.deltaTime;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        transform.position += movement;
        // Check if the dash key is pressed and the character is not already dashing
        if (Input.GetKeyDown(dashKey) && canDash)
        {
            
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {   
        canDash = false;
        isDashing = true;

        rb.velocity = movement.normalized * dashDistance;
        yield return new WaitForSeconds(dashDuration);
        rb.velocity = new Vector2(0f, 0f);
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

