using UnityEngine;

public class EnergyHealth : MonoBehaviour
{  
    [SerializeField] protected float maxEnergy = 100f; // Maximum energy value

    protected float currentEnergy;
    void Awake()
    {
        currentEnergy = maxEnergy; // Initialize current energy to max energy
    }

    public virtual void AddEnergy(float amount)
    {
        currentEnergy += amount; // Add energy
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy; // Cap at max energy
        }
    }
    public virtual void RemoveEnergy(float amount)
    {
        currentEnergy -= amount; // Remove energy
        if (currentEnergy < 0)
        {
            currentEnergy = 0; // Prevent negative energy
            Debug.Log("Energy depleted!"); // Log when energy is depleted
        }
    }

}
