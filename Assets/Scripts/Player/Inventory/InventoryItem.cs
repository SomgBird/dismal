using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventoryItem
{
    public InventoryItemData Data { get; private set; }
    public int StackSize { get; private set; }

    public InventoryItem(InventoryItemData data)
    {
        Data = data;
        AddToStack();
    }
    
    public InventoryItem(InventoryItemStackData stackData)
    {
        Data = stackData.referenceData;
        StackSize = stackData.amount;
    }

    public void AddToStack()
    {
        StackSize++;
    }
    
    public void AddToStack(int amount)
    {
        StackSize += amount;
    }

    
    public void RemoveFromStack()
    {
        StackSize--;
    }
    
    public void RemoveFromStack(int amount)
    {
        StackSize -= amount;
    }
}
