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
 
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private Vector2 mousePos;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        // Move the player
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        moveDir = new Vector2(x, y).normalized;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        rb.velocity = moveDir * moveSpeed;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

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

        rb.velocity = moveDir * dashDistance;
        yield return new WaitForSeconds(dashDuration);

        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}

