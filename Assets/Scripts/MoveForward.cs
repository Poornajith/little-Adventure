using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the object
    private void Update()
    {
        // Move the object forward
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
