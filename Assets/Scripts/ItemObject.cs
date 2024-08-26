using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public InventoryItemData referenceItem;

    public void PickupItem()
    {
		bool wasAdded = InventorySystem.instance.Add(referenceItem);

        if (wasAdded)
        {
			Destroy(gameObject);
		}
        else
        {
			Debug.Log("Item could not be picked up. Inventory is full.");
		}
        
    }
}
