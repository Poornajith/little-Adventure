using UnityEngine;

public class LazerCannonController : MonoBehaviour
{
    [Header("Lazer Cannon Settings")]
    [SerializeField] private GameObject lazerPrefab;
    [SerializeField] private Transform lazerSpawnPoint;
    [SerializeField] private float lazerCooldown = 1f;
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private MuzzleSplashPool muzzleSplashPool;

    private float lastLazerTime = 0f;
    private PlayerController playerController; // Reference to the central controller

    private void Awake() // Use Awake to get the controller reference early
    {
        playerController = GetComponent<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("LazerCannonController: PlayerController component not found on this GameObject!");
        }
    }

    private void Update()
    {
        // Handle lazer firing
        if (Input.GetButtonDown("Fire1") && Time.time >= lastLazerTime + lazerCooldown)
        {
            //FireLazer();
            playerController.Animator?.SetTrigger("Shoot");
            lastLazerTime = Time.time;
        }
    }

    public void FireLazer()
    {
        //if (lazerPrefab != null && lazerSpawnPoint != null)
        //{
        //    // Instantiate with the spawn point's position and rotation
        //    Instantiate(lazerPrefab, lazerSpawnPoint.position, lazerSpawnPoint.rotation);
        //}
        //else
        //{
        //    Debug.LogWarning("Lazer prefab or spawn point is not set!");
        //}

        // Trigger the firing animation using the Animator from PlayerController
        Bullet bullet = bulletPool.Get();
        bullet.transform.position = lazerSpawnPoint.position;
        bullet.transform.rotation = lazerSpawnPoint.rotation;

        MuzzleSplash muzzleSplash = muzzleSplashPool.Get();
        muzzleSplash.transform.position = lazerSpawnPoint.position;
        muzzleSplash.transform.rotation = lazerSpawnPoint.rotation;
    }
}
