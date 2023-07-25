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
        player.NavMeshController.NavMeshAgent.ResetPath();
    }

    public override void Exit()
    {
        base.Exit();
        
        player.InputHandler.ClearInteraction();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        player.InputHandler.InteractionTarget.PerformInteraction(player);
        stateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
