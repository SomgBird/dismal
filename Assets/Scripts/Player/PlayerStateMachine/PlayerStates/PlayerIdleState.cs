using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : FreeControlState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if(moveInput)
            stateMachine.ChangeState(player.WalkingState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
