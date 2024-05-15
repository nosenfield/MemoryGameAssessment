using System;
using TMPro;
using UnityEngine;

/// <summary>
/// It is often useful to have the prefab for a cloneable object visible on screen, but it needs to be removed from the scene at runtime.
/// This component removes any parent references for a prefab thus removing it from the display hierarchy
/// </summary>
public class RemovablePrefab : MonoBehaviour
{
    void Awake()
    {
        transform.parent = null;
    }
}