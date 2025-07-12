using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Public properties to allow other scripts to access core components
    public Rigidbody2D Rigidbody { get; private set; }
    public Animator Animator { get; private set; }

    public bool IsFacingRight { get; private set; } = true; // Initialize to true by default

    // Events for other components to subscribe to
    public event System.Action OnPlayerFlipped; // Notifies when the player has flipped

    private void Awake() // Use Awake to ensure components are retrieved before Start of others
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        if (Rigidbody == null)
        {
            Debug.LogError("PlayerController: Rigidbody2D component not found!");
        }
        if (Animator == null)
        {
            Debug.LogError("PlayerController: Animator component not found!");
        }
    }

    /// <summary>
    /// Flips the player's visual direction and updates the IsFacingRight state.
    /// Triggers the OnPlayerFlipped event.
    /// </summary>
    public void FlipPlayer()
    {
        IsFacingRight = !IsFacingRight;

        // Apply rotation directly
        if (IsFacingRight)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f); // Facing right
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f); // Facing left
        }

        OnPlayerFlipped?.Invoke(); // Notify subscribers
    }
}
