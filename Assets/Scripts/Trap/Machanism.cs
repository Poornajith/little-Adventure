using UnityEngine;

public abstract class Machanism : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Activate()
    {
        // Logic to activate the mechanism
        Debug.Log("Mechanism activated!");
    }
}
