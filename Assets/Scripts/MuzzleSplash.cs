using UnityEngine;

public class MuzzleSplash : MonoBehaviour
{
    public void Deactivate()
    {
        // Return the bullet to the pool
        //var pool = FindFirstObjectbyType<BulletPool>();
        MuzzleSplashPool pool = FindFirstObjectByType<MuzzleSplashPool>();
        if (pool != null)
        {
            pool.ReturnToPool(this);
        }
    }
}
