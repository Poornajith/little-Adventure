using System;
using UnityEditor;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform healthBarTransform; // Reference to the health bar transform
    void LateUpdate()
    {
        if (healthBarTransform != null)
        {
            // Make the health bar face the camera
            transform.position = healthBarTransform.transform.position;
        }
    }
}
