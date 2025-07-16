// 7/12/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float lifetime = 3f;

    private void OnEnable()
    {
        // Automatically return the bullet to the pool after a certain time
        Invoke(nameof(Deactivate), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke(); // Cancel any pending invokes when the bullet is disabled
    }

    private void Deactivate()
    {
        // Return the bullet to the pool
        //var pool = FindFirstObjectbyType<BulletPool>();
        BulletPool pool = FindFirstObjectByType<BulletPool>();
        if (pool != null)
        {
            pool.ReturnToPool(this);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Deactivate();
    }
}
