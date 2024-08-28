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
	public static event Action onInstanceSet;

	public void Unuse()
	{
		onUnuse?.Invoke();

		InventorySystem.instance.AddItem(itemInstance.itemType);
		CraftingSystem.instance.RemoveCraftingItem(itemInstance);
		CraftItemsTogetherDontKnowBetterName.instance.craftingItemsResult.Remove(itemInstance);
		ChangeCraftingSlotToUnactive();
		CraftItemsTogetherDontKnowBetterName.instance.ChangeStateOfResultButton();
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
