using UnityEngine;
using UnityEngine.UI;

public class BaseEnemyHealth : EnergyHealth
{
    [SerializeField] private Image healthbarFill;

    private BasicEnemy basicEnemy; // Reference to the BasicEnemy component 
    private void Start()
    {
        basicEnemy = GetComponent<BasicEnemy>();
        healthbarFill.fillAmount = currentEnergy / maxEnergy;
    }
    public override void AddEnergy(float amount)
    {
        base.AddEnergy(amount); // Call the base class method to add energy
        healthbarFill.fillAmount = currentEnergy/maxEnergy;
    }
    public override void RemoveEnergy(float amount)
    {
        base.RemoveEnergy(amount); // Call the base class method to remove energy
        healthbarFill.fillAmount = currentEnergy / maxEnergy;
        if (currentEnergy <= 0)
        {
            basicEnemy.Die(); // Call the Die method on BasicEnemy when energy is depleted
        }
    }
}
