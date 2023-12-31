using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>: MonoBehaviour where T : Component
{
    public static T Instance { get; private set; } 
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There are more than one Singleton on the scene!");
        }

        Instance = this as T;
    }
}
