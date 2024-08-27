using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button button;
    public InventoryItem itemInstance;
    InventoryItemData itemData;

    public void ChangeSlotToActive(InventoryItem item)
    {
        //InventoryItem newItem = new InventoryItem(item);
        itemData = item.itemType;
        itemInstance = item;
		icon.sprite = item.sprite;
        button.interactable = true;
    }

	public void ChangeSlotToUnactive()
	{
        icon.sprite = null;
		button.interactable = false;
	}
}
