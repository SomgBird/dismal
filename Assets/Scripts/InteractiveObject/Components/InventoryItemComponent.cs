using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemComponent : InteractiveComponent
{
    [SerializeField] private InventoryItemData referenceData;

    public override void PerformInteraction(Player player)
    {
        base.PerformInteraction(player);
        
        player.InventorySystem.Add(referenceData);
        Debug.Log(player.InventorySystem.ItemList[0].Data.displayName);
    }
}
