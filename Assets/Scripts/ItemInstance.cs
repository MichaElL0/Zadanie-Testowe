using System;
using UnityEngine;

//[Serializable]
public class ItemInstance
{
    public InventoryItemData itemType;
    public Sprite sprite;
    public GameObject prefab;

    public ItemInstance(InventoryItemData newItem)
    {
        itemType = newItem;
        sprite = newItem.icon;
        prefab = newItem.prefab;
    }
}
