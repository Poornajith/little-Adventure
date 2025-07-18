using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static HealthController Instance { get; private set; }

    [SerializeField] private int maxHeartCount = 5;
    [SerializeField] private GameObject heartImagePrefab;
    
    private int currentHeartCount;
    private GameObject[] heartImages;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentHeartCount = maxHeartCount;
        // Initialize heart images
        heartImages = new GameObject[maxHeartCount];
        for (int i = 0; i < maxHeartCount; i++)
        {
            heartImages[i] = Instantiate(heartImagePrefab, transform);
            heartImages[i].gameObject.SetActive(true); // Ensure the heart image is active
        }
        
    }

    public void TakeDamage(int count)
    {
        currentHeartCount -= count;
        if (currentHeartCount < 0)
        {
            currentHeartCount = 0; // Prevent negative heart count
            Debug.LogWarning("HealthController: Current heart count cannot be less than zero.");
        }
        UpdateHeartImages();
        CheckPointController.Instance.Respawn(); // Respawn player at the last checkpoint
    }

    public void Heal(int count)
    {
        currentHeartCount += count;
        if (currentHeartCount > maxHeartCount)
        {
            currentHeartCount = maxHeartCount; // Prevent exceeding max heart count
            Debug.LogWarning("HealthController: Current heart count cannot exceed maximum heart count.");
        }
        UpdateHeartImages();
    }

    private void UpdateHeartImages()
    {
        // deactivate last active game object from the heartImages array
        for (int i = 0; i < maxHeartCount; i++)
        {
            if (i < currentHeartCount)
            {
                heartImages[i].SetActive(true); // Show heart image
            }
            else
            {
                heartImages[i].SetActive(false); // Hide heart image
            }
        }
    }
}
