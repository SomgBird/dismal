using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private Dictionary<InventoryItemData, InventoryItem> itemDictionary;
    public List<InventoryItem> ItemList { get; private set; }

    private void Awake()
    {
        itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        ItemList = new List<InventoryItem>();
    }


    public InventoryItem Get(InventoryItemData referenceData) 
        => itemDictionary.TryGetValue(referenceData, out InventoryItem value) ? value : null;

    
    public void Add(InventoryItemStackData stackData)
    {
        if (itemDictionary.TryGetValue(stackData.referenceData, out InventoryItem value))
        {
            value.AddToStack(stackData.amount);
        }
        else
        {
            InventoryItem newItem = new(stackData.referenceData);
            ItemList.Add(newItem);
            itemDictionary.Add(stackData.referenceData, newItem);
        }
    }

    
    public void Remove(InventoryItemStackData stackData)
    {
        if (itemDictionary.TryGetValue(stackData.referenceData, out InventoryItem value))
        {
            if (value.StackSize - stackData.amount < 0)
                throw new IndexOutOfRangeException("You are trying to remove more items than you have!");
            value.RemoveFromStack(stackData.amount);
            
            if (value.StackSize == 0)
            {
                ItemList.Remove(value);
                itemDictionary.Remove(stackData.referenceData);
            }
        }
    }

    public bool MeetsRequirements(IEnumerable<InventoryRequirement> requirements)
        => requirements.All(requirement => requirement.HasRequirement(this));
    
}
