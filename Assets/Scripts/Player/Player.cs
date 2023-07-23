using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    #region StateMachine

    public PlayerStateMachine StateMachine { get; private set; }
    
    public PlayerIdleState IdleState { get; private set; }
    public PlayerWalkingState WalkingState { get; private set; }
    public PlayerInteractionState InteractionState { get; private set; }

    #endregion
    
    #region Components

    public PlayerNavMeshController NavMeshController { get; private set; }
    public PlayerInputHandler  InputHandler  { get; private set; }
    
    #endregion
    
    #region UnityCallbacks

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        
        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        WalkingState = new PlayerWalkingState(this, StateMachine, playerData);
        InteractionState = new PlayerInteractionState(this, StateMachine, playerData);
    }

    void Start()
    {
        NavMeshController = GetComponent<PlayerNavMeshController>();
        InputHandler = GetComponent<PlayerInputHandler>();
        
        StateMachine.Initialize(IdleState);
    }

    
    void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }


    private void FixedUpdate()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    #endregion
}
