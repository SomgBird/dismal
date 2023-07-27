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


    public void Add(InventoryItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddToStack();
        }
        else
        {
            InventoryItem newItem = new(referenceData);
            ItemList.Add(newItem);
            itemDictionary.Add(referenceData, newItem);
        }
    }

    public void Add(InventoryItemStackData stackData)
    {
        for (int i = 0; i < stackData.amount; i++)
        {
            Add(stackData.referenceData);
        }
    }

    public void Remove(InventoryItemData referenceData)
    {
        if (itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.RemoveFromStack();

            if (value.StackSize == 0)
            {
                ItemList.Remove(value);
                itemDictionary.Remove(referenceData);
            }
        }
    }
    
    public void Remove(InventoryItemStackData stackData)
    {
        for (int i = 0; i < stackData.amount; i++)
        {
            Remove(stackData.referenceData);
        }
    }

    public bool MeetsRequirements(IEnumerable<InventoryRequirement> requirements)
        => requirements.All(requirement => requirement.HasRequirement(this));
    
}
