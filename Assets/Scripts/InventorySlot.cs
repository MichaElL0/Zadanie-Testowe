using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button button;

    public void ChangeSlotToActive(InventoryItemData item)
    {
        icon.sprite = item.icon;
        button.interactable = true;
    }

	public void ChangeSlotToUnactive()
	{
        icon.sprite = null;
		button.interactable = false;
	}
}
