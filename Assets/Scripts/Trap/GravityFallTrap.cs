using UnityEngine;

public class GravityFallTrap : Machanism
{
    [SerializeField] private float gravityScale = 5f; // Speed at which the trap falls
    private Rigidbody2D rb;
    private bool isActive = false;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // Initially set gravity scale to zero
    }

    // overide the original Activate method to implement gravity fall trap logic
    public override void Activate()
    {
        if (!isActive)
        {
            isActive = true;            
            rb.gravityScale = gravityScale; // Set gravity scale to a positive value
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // deal damage to the player 
        }
        else
        {
            isActive = false; // Reset the trap state if it hits something else
        }
    }
}
