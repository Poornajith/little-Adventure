using System;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    [SerializeField] protected bool isActive = true; // Indicates if the trigger is active
    [SerializeField] protected float activationTime;
    [SerializeField] protected GameObject machanismToActivate; // The mechanism to activate when the trigger is activated

    private Machanism machanism; // Reference to the Machanism component
    private void Awake()
    {
        machanism = machanismToActivate.GetComponent<Machanism>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isActive && collision.CompareTag("Player"))
        {            
            if (machanism != null || isActive)
            {               
                Debug.Log("Trigger activated by player.");
                Invoke(nameof(ActivateTimerMachanism), activationTime); // Reset the trigger after a delay
            }
            else
            {
                Debug.LogWarning("No Machanism component found on the specified GameObject.");
            }
        }
    }

    private void ActivateTimerMachanism()
    {        
        machanism.Activate(); 
        isActive = false;
    }

}
