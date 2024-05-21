using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D coll;
    private bool isJumping = false;
    private bool isClimbing = false;
    private bool isGrounded = false;
    private float inputHorizontal;
    private float inputVertical;
    private bool facingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // Move left/right
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, rb.velocity.y);

        // Check if grounded
        isGrounded = IsGrounded();

        // Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }

        // Climb ladder
        if (isClimbing)
        {
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * moveSpeed);
            rb.gravityScale = 0f;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        // Flip character
        if (inputHorizontal > 0 && !facingRight)
        {
            Flip();
        }
        else if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private bool IsGrounded()
    {
        // Check if touching the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundLayer);
        return hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Enter ladder area
        if (other.CompareTag("Ladder"))
        {
            isClimbing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Exit ladder area
        if (other.CompareTag("Ladder"))
        {
            isClimbing = false;
        }
    }

    private void Flip()
    {
        // Flip character
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
