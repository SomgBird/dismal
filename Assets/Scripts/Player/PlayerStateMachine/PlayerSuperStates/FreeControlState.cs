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
        
        moveInput = player.InputHandler.MoveInput;
        interactInput = player.InputHandler.InteractInput;
        
        if (player.InputHandler.InteractionScheduled)
        {
            if (Vector3.Distance(player.InputHandler.DestinationPosition, player.transform.position) < playerData.interactiveDistance)
            {
                stateMachine.ChangeState(player.InteractionState);
                player.InputHandler.ClearInteraction();
                return;
            }
        }        
        
        if (moveInput || interactInput)
        {
            player.NavMeshController.ClearDestinationMark();
            player.NavMeshController.SetDestination(player.InputHandler.DestinationPosition);
        }
                
        if (moveInput)
        {
            player.NavMeshController.ShowDestinationMark();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
