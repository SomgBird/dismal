using UnityEngine;

public class PlayerInteractionState : NoControlState
{
    public PlayerInteractionState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        Debug.Log("interaction");
        NavMeshManager.Instance.NavMeshAgent.ResetPath();
    }

    public override void Exit()
    {
        base.Exit();
        
        InputManager.Instance.ClearInteraction();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        InputManager.Instance.InteractionTarget.PerformInteraction(player);
        
        if (DialogueManager.Instance.DialogueIsPlaying)
            stateMachine.ChangeState(player.DialogueState);
        else
            stateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
