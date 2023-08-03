using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeControlState : PlayerState
{
    protected bool 
        moveInput,
        interactInput;
    
    public FreeControlState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        moveInput = InputManager.Instance.MoveInput;
        interactInput = InputManager.Instance.InteractInput;

        if (moveInput || interactInput)
        {
            NavMeshManager.Instance.ClearDestinationMark();
            NavMeshManager.Instance.SetDestination(InputManager.Instance.DestinationPosition);
        }
                
        if (moveInput)
        {
            NavMeshManager.Instance.ShowDestinationMark();
        }
        
        if (DialogueManager.Instance.DialogueIsPlaying)
            stateMachine.ChangeState(player.DialogueState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
