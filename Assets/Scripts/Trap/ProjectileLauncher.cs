// 7/17/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class ProjectileLauncher : Machanism
{
    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab; // Prefab of the projectile to launch
    [SerializeField] private int projectileCount = 5; // Number of projectiles to launch
    [SerializeField] private float delayBetweenProjectiles = 0.5f; // Delay between each projectile launch
    [SerializeField] private Vector2 launchDirection = Vector2.right; // Direction to launch the projectiles
    [SerializeField] private float projectileSpeed = 5f; // Speed of the projectiles

    public override void Activate()
    {
        // Start the coroutine to launch projectiles
        StartCoroutine(LaunchProjectiles());
    }

    private System.Collections.IEnumerator LaunchProjectiles()
    {
        for (int i = 0; i < projectileCount; i++)
        {
            // Instantiate the projectile
            Spike spike = SpikePool.instance.Get();
            spike.transform.position = transform.position; // Set the position to the trap's position
            spike.transform.rotation = transform.rotation; // Reset rotation

            // Set the velocity of the projectile
            Rigidbody2D rb = spike.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = launchDirection.normalized * projectileSpeed;
            }

            // Wait for the specified delay before launching the next projectile
            yield return new WaitForSeconds(delayBetweenProjectiles);
        }
    }
}
