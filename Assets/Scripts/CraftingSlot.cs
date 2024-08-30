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
	

	public static event Action OnUnuse;

	private void OnEnable()
	{
		CraftingResultSystem.OnCraftItem += ChangeCraftingSlotToUnactive;
	}

	private void OnDisable()
	{
		CraftingResultSystem.OnCraftItem += ChangeCraftingSlotToUnactive;
	}

	public void Unuse()
	{
		OnUnuse?.Invoke();

		InventorySystem.instance.AddItem(itemInstance.itemType);
		CraftingSystem.instance.RemoveCraftingItem(itemInstance);
		CraftingResultSystem.instance.craftingItemsResult.Remove(itemInstance);
		ChangeCraftingSlotToUnactive();
		CraftingResultSystem.instance.ChangeStateOfResultButton();
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
