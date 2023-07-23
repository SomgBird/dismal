


using UnityEngine;

public class PlayerInteractionState : NoControlState
{
    public delegate void Interaction();
    public event Interaction playerInteracted;
    
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
        
        playerInteracted?.Invoke();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        // TODO: perform interaction
        stateMachine.ChangeState(player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
