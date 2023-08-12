using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInventoryItemComponent : InteractiveComponent
{
    public List<InventoryItemStackData> itemsToRemove;
    [SerializeField] private Player player;

    public override bool PerformInteraction()
    {
        RemoveItemFromInventory(player.InventorySystem);
        return true;
    }

    private void RemoveItemFromInventory(InventorySystem inventorySystem)
    {
        foreach (InventoryItemStackData itemData in itemsToRemove)
        {
            inventorySystem.Remove(itemData);
        }
    }
}
