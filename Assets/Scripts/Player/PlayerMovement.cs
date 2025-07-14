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

    private PlayerController playerController; // Reference to the central controller

    private bool isGrounded; // This can remain local to movement logic

    private void Awake() // Use Awake to get the controller reference early
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerMovement: PlayerController component not found on this GameObject!");
        }
    }

    private void Update()
    {
        // Handle movement
        float moveInput = Input.GetAxis("Horizontal");
        playerController.Rigidbody.linearVelocity = new Vector2(moveInput * moveSpeed, playerController.Rigidbody.linearVelocity.y);

        // Update animator parameters
        playerController.Animator.SetFloat("Blend", Mathf.Abs(moveInput));
        playerController.Animator.SetBool("IsGrounded", isGrounded);

        // Flip the sprite based on movement direction
        if (moveInput > 0 && !playerController.IsFacingRight)
        {
            playerController.FlipPlayer();
        }
        else if (moveInput < 0 && playerController.IsFacingRight)
        {
            playerController.FlipPlayer();
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerController.Rigidbody.linearVelocity = new Vector2(playerController.Rigidbody.linearVelocity.x, jumpForce);
            playerController.Animator.SetTrigger("Jump");
        }
    }

    private void FixedUpdate()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
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
