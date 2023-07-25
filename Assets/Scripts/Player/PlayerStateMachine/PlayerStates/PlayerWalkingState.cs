using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : FreeControlState
{
    public PlayerWalkingState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("walk");
    }

    public override void Exit()
    {
        base.Exit();
        player.NavMeshController.ClearDestinationMark();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
                
        if (player.InputHandler.InteractionScheduled)
        {
            if (Vector3.Distance(player.InputHandler.DestinationPosition, player.transform.position) < playerData.interactiveDistance)
            {
                stateMachine.ChangeState(player.InteractionState);
                return;
            }
        }     
        
        if (player.NavMeshController.NavMeshAgent.remainingDistance < 0.01 && !player.NavMeshController.NavMeshAgent.pathPending)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
