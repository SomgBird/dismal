using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckInventoryRequirementComponent : InteractiveComponent
{
    public List<InventoryRequirement> requirements;

    public override bool PerformInteraction(Player player)
    {
        if (player.InventorySystem.MeetsRequirements(requirements))
        {
            Debug.Log("Meets requirements!");
            return true;
        }

        Debug.Log("Does not meet requirements!");
        return false;
    }
}
