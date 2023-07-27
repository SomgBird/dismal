using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct InventoryRequirement
{
    public InventoryItemStackData requiredItems;

    public bool HasRequirement(InventorySystem inventorySystem)
    {
        InventoryItem item = inventorySystem.Get(requiredItems.referenceData);
        return item != null && item.StackSize >= requiredItems.amount;
    }
}
