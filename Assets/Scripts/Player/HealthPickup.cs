using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {            
            HealthController.Instance.Heal(1); // Heal the player by 1 heart
            gameObject.SetActive(false); // Deactivate the health pickup object
        }
    }
}
