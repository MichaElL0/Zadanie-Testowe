using System;
using UnityEngine;


[Serializable]
public class InventoryItem
{
    public InventoryItemData itemType;
    public Sprite sprite;
    public GameObject prefab;

    public InventoryItem(InventoryItemData newItem)
    {
        itemType = newItem;
        sprite = newItem.icon;
        prefab = newItem.prefab;
    }

    
}
