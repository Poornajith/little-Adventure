using UnityEngine;

public class Destroyable : MonoBehaviour
{
    [SerializeField] private int health = 3;
    //[SerializeField] private GameObject destroyEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Bullet"))
        {
            TakeDamage(1);
            collision.gameObject.SetActive(false);
        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            // Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
    }
}
