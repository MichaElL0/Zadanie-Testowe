using System;


[Serializable]
public class InventoryItem
{
    public InventoryItemData item {  get; private set; }

    public InventoryItem(InventoryItemData newItem)
    {
        item = newItem; ;
    }

    
}
