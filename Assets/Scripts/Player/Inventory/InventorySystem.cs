using System;
using System.Collections;
using System.Collections.Generic;
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
}
