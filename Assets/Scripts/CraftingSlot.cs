using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingSlot : MonoBehaviour
{
	public Image icon;
	public Button unuseButton;
	ItemInstance itemInstance;

	public static event Action onUnuse;

	public void Unuse()
	{
		onUnuse?.Invoke();
		print("Move item back to inventory");

		print("Remove item from crafting");

		InventorySystem.instance.AddItem(itemInstance.itemType);
		CraftingSystem.instance.RemoveCraftingItem(itemInstance);
		ChangeCraftingSlotToUnactive();

		print("Update UI");

	}

	public void ChangeCraftingSlotToActive(ItemInstance item)
	{
		itemInstance = item;
		icon.sprite = itemInstance.sprite;
		unuseButton.interactable = true;
	}

	public void ChangeCraftingSlotToUnactive()
	{
		icon.sprite = null;
		itemInstance = null;
		unuseButton.interactable = false;
	}
}
