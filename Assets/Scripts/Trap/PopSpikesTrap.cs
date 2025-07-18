using UnityEngine;

public class PopSpikesTrap : Machanism
{
    [SerializeField] private float popHeight = 1f; // Damage dealt by the spikes
    [SerializeField] private float popDuration = 0.5f; // Duration for which the spikes are popped up

    private Vector2 initialPosition; // Store the initial position of the trap

    private void Awake()
    {
        // Save the initial position of the trap
        initialPosition = transform.position;
    }

    public override void Activate()
    {
        // Start the coroutine to pop the spikes
        StartCoroutine(PopSpikes());
    }

    private System.Collections.IEnumerator PopSpikes()
    {
        float elapsedTime = 0f;
        Vector2 targetPosition = new Vector2(initialPosition.x, initialPosition.y + popHeight);

        // Gradually move the spikes up over the duration
        while (elapsedTime < popDuration)
        {
            transform.position = Vector2.Lerp(initialPosition, targetPosition, elapsedTime / popDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the spikes reach the exact target position
        transform.position = targetPosition;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController.Instance.TakeDamage(1); // Deal damage to the player 
        }
    }
}
