using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CheckPointController.Instance.SetCheckpoint(other.transform.position); // Deal damage to the player 
        }
    }
}
