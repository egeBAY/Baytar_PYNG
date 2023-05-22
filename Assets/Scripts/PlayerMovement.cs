using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private bool canDash = true;
    private bool isDashing; // Whether the character is currently dashing or not
    public float dashDistance = 5f; // The distance the character will dash
    public float dashDuration = 0.5f; // The duration of the dash
    private float dashingCooldown = 1f;
    private KeyCode dashKey = KeyCode.Space; // The key to press for dashing

    private Vector3 movement;

    public Animator animator;


    void FixedUpdate()
    {
        if (isDashing) return;

        // Move the player
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f) * moveSpeed * Time.deltaTime;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        transform.position += movement;
        // Check if the dash key is pressed and the character is not already dashing
        if (Input.GetKey(dashKey) && canDash)
        {
            
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {   
        canDash = false;
        isDashing = true;

        Vector2 targetPos = transform.position + movement.normalized * dashDistance;
        transform.position = Vector3.Lerp(transform.position, targetPos, dashDuration);
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

