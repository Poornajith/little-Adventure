using UnityEngine;
using UnityEngine.UI;

public class TakeDamageBase : MonoBehaviour
{
    [SerializeField] private float damage;

    private BaseEnemyHealth BaseEnemyHealth;

    private void Start()
    {
        BaseEnemyHealth = GetComponent<BaseEnemyHealth>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BaseEnemyHealth.RemoveEnergy(damage);
        }
    }
}
