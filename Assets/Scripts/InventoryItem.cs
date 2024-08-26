using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    public InventoryItemData item {  get; private set; }

    public void InvetoryItem(InventoryItemData newItem)
    {
        item = newItem; ;
    }

    
}
