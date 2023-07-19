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
        
        if (player.NavMeshController.PlayerNavMeshAgent.remainingDistance < 0.01)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
