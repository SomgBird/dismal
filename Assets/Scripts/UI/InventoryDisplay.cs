using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventorySystem inventorySystem;

    [SerializeField] private Transform itemContent;

    [SerializeField] private GameObject inventoryItemView;
    // Start is called before the first frame update
    void Start()
    {
        InventorySystem.InventoryUpdated += UpdateInventoryContent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void UpdateInventoryContent()
    {
        CleanInventoryContent();
        
        foreach (InventoryItem item in inventorySystem.ItemList)
        {
            GameObject obj = Instantiate(inventoryItemView, itemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TMP_Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var itemQuantity = obj.transform.Find("ItemQuantity").GetComponent<TMP_Text>();

            itemName.text = item.Data.displayName;
            itemIcon.sprite = item.Data.icon;
            itemQuantity.text = item.StackSize.ToString();
        }
    }

    public void CleanInventoryContent()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
    }
}
