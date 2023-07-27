using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AddInventoryItemComponent : InteractiveComponent
{
    public List<InventoryItemStackData> itemsToAdd;

    public override bool PerformInteraction(Player player)
    {
        AddToInventory(player.InventorySystem);
        return true;
    }

    private void AddToInventory(InventorySystem inventorySystem)
    {
        foreach (InventoryItemStackData itemData in itemsToAdd)
        {
            inventorySystem.Add(itemData);
        }
        Debug.Log(inventorySystem.ItemList[0].Data.displayName);
    }
}
