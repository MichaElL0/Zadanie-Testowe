using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemsTogetherDontKnowBetterName : MonoBehaviour
{
	public static CraftItemsTogetherDontKnowBetterName instance;

	public Image icon;
	public Button craftButton;
	ItemInstance itemInstance;

	[Header("Crafting items")]
	public List<ItemInstance> craftingItemsResult;
	public List<InventoryItemData> craftingItemsResultData;

	private Dictionary<InventoryItemData, Sprite> craftingResultSprites;

	public static event Action onCraftItem;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}

		craftingItemsResult = new List<ItemInstance>();

		craftingResultSprites = new Dictionary<InventoryItemData, Sprite>
		{
			{ craftingItemsResultData[0], craftingItemsResultData[0].icon }, // Wooden Plank
            { craftingItemsResultData[1], craftingItemsResultData[1].icon }, // Axe
            { craftingItemsResultData[2], craftingItemsResultData[2].icon }, // Nail
            { craftingItemsResultData[3], craftingItemsResultData[3].icon }  // Plank with Nails
        };
	}

	private void OnEnable()
	{
		InventorySlot.onItemCraft += ChangeStateOfResultButton;
	}

	public void Craft()
	{
		if (InventorySystem.instance.inventoryItems.Count < InventorySystem.instance.inventorySpace)
		{
			InventoryItemData item1 = craftingItemsResult[0].itemType;
			InventoryItemData item2 = craftingItemsResult[1].itemType;

			InventoryItemData result = WhatIsTheResult();

			if (result != null)
			{
				onCraftItem?.Invoke();
				InventorySystem.instance.AddItem(result);
				craftingItemsResult.Clear();
				CraftingSystem.instance.craftingItems.Clear();
				icon.sprite = null;
				result = null;
				//print($"Crafted: {result.name}");
			}
			else
			{
				print("No valid combination!");
			}
		}
		else
		{
			print("No space to craft!");
		}
	}

	public void ChangeStateOfResultButton()
	{
		if (CraftingSystem.instance.craftingItems.Count == 2)
		{
			craftButton.interactable = true;
			InventoryItemData result = WhatIsTheResult();

			if (result != null && craftingResultSprites.TryGetValue(result, out Sprite sprite))
			{
				icon.sprite = sprite;
			}
			else
			{
				Debug.Log("No valid item to craft.");
				icon.sprite = null;
			}
		}
		else
		{
			icon.sprite = null;
			itemInstance = null;
			craftButton.interactable = false;
		}
	}

	public void ChangeSlotToActive(ItemInstance item)
	{
		icon.sprite = item.sprite;
		craftButton.interactable = true;
	}

	public void ChangeSlotToUnactive()
	{
		icon.sprite = null;
		itemInstance = null;
		craftButton.interactable = false;
	}

	private InventoryItemData WhatIsTheResult()
	{
		InventoryItemData item1 = craftingItemsResult[0].itemType;
		InventoryItemData item2 = craftingItemsResult[1].itemType;

		if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Wood)
		{
			return craftingItemsResultData[0]; // Wooden Plank
		}
		else if ((item1.type == InventoryItemData.ItemType.Wood || item1.type == InventoryItemData.ItemType.Rock) &&
				 (item2.type == InventoryItemData.ItemType.Wood || item2.type == InventoryItemData.ItemType.Rock))
		{
			return craftingItemsResultData[1]; // Axe
		}
		else if (item1.type == InventoryItemData.ItemType.Iron && item2.type == InventoryItemData.ItemType.Iron)
		{
			return craftingItemsResultData[2]; // Nail
		}
		else if ((item1.type == InventoryItemData.ItemType.Nail || item1.type == InventoryItemData.ItemType.Plank) &&
				 (item2.type == InventoryItemData.ItemType.Plank || item2.type == InventoryItemData.ItemType.Nail))
		{
			return craftingItemsResultData[3]; // Plank with Nails
		}
		else
		{
			return null;
		}
	}
}
