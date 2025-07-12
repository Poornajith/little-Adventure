using UnityEngine;

public class LazerCannonController : MonoBehaviour
{
    [Header("Lazer Cannon Settings")]
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private Transform lazerSpawnPoint;
    [SerializeField] private float lazerCooldown = 1f;

    private float lastLazerTime = 0f;
    private Animator animator;

    private void Start()
    {
        // Initialize animator if available
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogWarning("Animator component not found on LazerCannonController!");
        }
    }
    private void Update()
    {
        // Handle lazer firing
        if (Input.GetButtonDown("Fire1") && Time.time >= lastLazerTime + lazerCooldown)
        {
            FireLazer();
            lastLazerTime = Time.time;
        }
    }
    private void FireLazer()
    {
        if (lazerPrefab != null && lazerSpawnPoint != null)
        {
            Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("Lazer prefab or spawn point is not set!");
        }
        animator?.SetTrigger("Shoot"); // Trigger the firing animation if animator is available
    }
}
