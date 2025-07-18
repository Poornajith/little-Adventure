using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController Instance { get; private set; }

    [SerializeField] private GameObject CheckPoint;
    private GameObject currentCheckPoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentCheckPoint = Instantiate(CheckPoint, transform);
    }
    public void SetCheckpoint(Vector2 position)
    {
        currentCheckPoint.transform.position = position;
    }
    public void Respawn()
    {
        PlayerController playerController = FindFirstObjectByType<PlayerController>();
        // Reset player position to the last checkpoint
        playerController.transform.position = currentCheckPoint.transform.position;
        // Reset health to maximum
        // currentHeartCount = maxHeartCount;
        // UpdateHeartImages();
    }
}
