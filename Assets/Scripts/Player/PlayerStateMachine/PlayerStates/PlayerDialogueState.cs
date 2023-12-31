using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogueState : NoControlState
{
    public PlayerDialogueState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }

    public override void Enter()
    {
        Debug.Log("dialogue");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (!DialogueManager.Instance.DialogueIsPlaying)
            stateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
