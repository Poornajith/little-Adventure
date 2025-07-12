// 7/5/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    protected Animator animator;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Update animator parameters
        animator.SetFloat("Blend", Mathf.Abs(moveInput)); // Assuming "Blend" is used for running animation
        animator.SetBool("IsGrounded", isGrounded);

        if(Mathf.Abs(rb.linearVelocity.x) > 0f && isGrounded)
        {
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        // Flip the sprite based on movement direction
        if (moveInput > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && isFacingRight)
        {
            Flip();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump"); // Assuming "Jump" is the trigger for jump animation
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Facing right (or initial direction)
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Facing left
        }
        isFacingRight = !isFacingRight;
        //Vector3 localScale = transform.localScale;
        //localScale.x *= -1;
        //transform.localScale = localScale;
    }

    private void OnDrawGizmosSelected()
    {
        // Draw ground check radius in the editor
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
