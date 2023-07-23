using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoControlState : PlayerState
{

    public NoControlState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData)
    {
    }
}
