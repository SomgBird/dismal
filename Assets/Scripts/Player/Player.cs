using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    #region Compunents

    public PlayerNavMeshController NavMeshController { get; private set; }
    public PlayerInputHandler  InputHandler  { get; private set; }
    
    #endregion
    
    
    private void Awake()
    {
        
    }

    void Start()
    {
        NavMeshController = GetComponent<PlayerNavMeshController>();
        InputHandler = GetComponent<PlayerInputHandler>();
    }

    
    void Update()
    {
        
    }


    private void FixedUpdate()
    {
        
    }
}
