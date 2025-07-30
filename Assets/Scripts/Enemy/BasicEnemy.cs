// 7/24/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [Header("Patrol Settings")]
    [SerializeField] private Transform walkPointA; // First patrol point
    [SerializeField] private Transform walkPointB; // Second patrol point
    [SerializeField] private float patrolSpeed = 2f;
    [SerializeField] private float chaseSpeed = 2f;

    [Header("Player Detection")]
    [SerializeField] private Transform player; // Reference to the player
    [SerializeField] private float detectionRange = 5f; // Range to detect the player
    [SerializeField] private float attackRange = 1.5f; // Range to attack the player

    [Header("Attack Settings")]
    [SerializeField] private float timeBetweenAttacks = 2f; // Time between attacks
    [SerializeField] private int attackDamage = 1; // Damage dealt to the player

    [Header("Death Settings")]
    [SerializeField] private float deathDelay = 2f; // Delay before destroying the enemy after death

    private float attackCooldown = 0f;

    private Vector3 currentTarget; // Current patrol target
    private bool isChasingPlayer = false;
    private Animator animator; // Reference to the enemy's animator (if any)
    private bool isFacingRight = true; // Track the facing direction of the enemy

    private void Start()
    {
        // Set the initial patrol target
        currentTarget = walkPointA.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Handle attack cooldown
        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        // Check if the player is within detection range
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= detectionRange)
        {
            // Check if the player is within the patrol area
            if (player.position.x >= Mathf.Min(walkPointA.position.x, walkPointB.position.x) &&
                player.position.x <= Mathf.Max(walkPointA.position.x, walkPointB.position.x))
            {
                isChasingPlayer = true;

                // Check if the player is within attack range
                if (distanceToPlayer <= attackRange)
                {
                    AttackPlayer();
                }
                else
                {
                    ChasePlayer();
                }
            }
            else
            {
                isChasingPlayer = false;
            }
        }
        else
        {
            isChasingPlayer = false;
        }

        // Patrol if not chasing the player
        if (!isChasingPlayer)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        // Move towards the current patrol target
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, patrolSpeed * Time.deltaTime);

        // Flip the enemy sprite based on the direction of movement
        if ((currentTarget.x > transform.position.x && !isFacingRight) || (currentTarget.x < transform.position.x && isFacingRight))
        {
            Flip();
        }

        // Switch target when reaching the current patrol point
        if (Mathf.Abs(transform.position.x - currentTarget.x) < 0.1f)
        {
            currentTarget = currentTarget == walkPointA.position ? walkPointB.position : walkPointA.position;
        }

        animator?.SetBool("IsWalking", true); // Set walking animation if available
        animator?.SetBool("IsChasing", false); // Ensure chasing animation is not active while patrolling
    }

    private void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        // Flip the enemy sprite based on the direction of movement
        if ((player.position.x > transform.position.x && !isFacingRight) || (player.position.x < transform.position.x && isFacingRight))
        {
            Flip();
        }
        animator?.SetBool("IsChasing", true); // Set chasing animation if available
    }

    private void AttackPlayer()
    {
        if (attackCooldown <= 0)
        {
            Debug.Log("Enemy attacks the player!");

            // Add attack logic here (e.g., reduce player health)
            attackCooldown = timeBetweenAttacks;
            animator?.SetTrigger("Attack"); // Trigger attack animation if available
        }
    }


    private void Flip()
    {
        // Flip the enemy's sprite based on the direction of movement
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions with other objects (e.g., bullets)
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            collision.gameObject.SetActive(false); // Deactivate the bullet
        }
    }

    private void TakeDamage(int damage)
    {
        // Handle taking damage (e.g., reduce health)
        // Example: HealthController.Instance.TakeDamage(damage);
        Debug.Log($"Enemy takes {damage} damage!");
        // If health reaches zero, destroy the enemy
        // Destroy(gameObject);
    }

    public void DamagePlayer()
    {
        // Method to deal damage to the player
        HealthController.Instance.TakeDamage(attackDamage);
    }
    public void Die()
    {
        // Handle enemy death (e.g., play death animation, drop loot)
        Debug.Log("Enemy died!");
        animator?.SetTrigger("Dead"); // Trigger death animation if available
        // Optionally destroy the enemy after a delay
        Destroy(gameObject, deathDelay);
    }
    private void OnDrawGizmosSelected()
    {
        // Draw detection and attack ranges in the editor
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
