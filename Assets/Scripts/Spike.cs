using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HealthController.Instance.TakeDamage(1); // Deal damage to the player 
        }
    }
}
