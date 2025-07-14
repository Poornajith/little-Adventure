// 7/12/2025 AI-Tag
// This was created with the help of Assistant, a Unity Artificial Intelligence product.

using System;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab; // The prefab to instantiate
    [SerializeField] private int initialSize = 10; // Initial size of the pool

    private List<T> pool = new List<T>();

    protected virtual void Awake()
    {
        // Pre-fill the pool with inactive objects
        for (int i = 0; i < initialSize; i++)
        {
            AddObjectToPool();
        }
    }

    // Get an inactive object from the pool
    public T Get()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        // If no inactive objects are available, add a new one to the pool
        return AddObjectToPool();
    }

    // Return an object back to the pool
    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
    }

    // Add a new object to the pool
    private T AddObjectToPool()
    {
        T newObj = Instantiate(prefab, transform);
        newObj.gameObject.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
