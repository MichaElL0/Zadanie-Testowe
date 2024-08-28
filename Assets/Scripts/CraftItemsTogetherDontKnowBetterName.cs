using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftItemsTogetherDontKnowBetterName : MonoBehaviour
{
	public static CraftItemsTogetherDontKnowBetterName instance;

	public Image icon;
	public Button craftButton;
	[SerializeField] ItemInstance itemInstance;

	[Header("Crafting items")]

	public List<ItemInstance> craftingItemsResult;

	public List<InventoryItemData> craftingItemsResultData;


	private void OnEnable()
	{
		InventorySlot.onItemCraft += ChangeStateOfResultButton;
	}


	private void Awake()
	{
		instance = this;
		craftingItemsResult = new List<ItemInstance>();
	}

	public void Craft()
	{
		if(InventorySystem.instance.inventoryItems.Count < InventorySystem.instance.inventorySpace)
		{
			InventoryItemData item1 = craftingItemsResult[0].itemType;
			InventoryItemData item2 = craftingItemsResult[1].itemType;

			if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Wood)
			{
				print("Wooden plank");
				return;
			}
			else if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Rock)
			{
				print("Axe");
				return;
			}
			else if (item1.type == InventoryItemData.ItemType.Iron && item2.type == InventoryItemData.ItemType.Iron)
			{
				print("Nail");
				return;
			}
			else if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Nail)
			{
				print("Plank with nails");
				return;
			}
			else
			{
				print("No suh combination!");
				return;
			}
		}
		else
		{
			print("No space to craft!");
			return;
		}
		
	}

	public void ChangeStateOfResultButton()
    {
		if(CraftingSystem.instance.craftingItems.Count == 2)
		{
			craftButton.interactable = true;
			InventoryItemData item1 = craftingItemsResult[0].itemType;
			InventoryItemData item2 = craftingItemsResult[1].itemType;

			string result = WhatIsTheResult();

			if(result == "Wooden plank")
			{
				icon.sprite = craftingItemsResultData[0].icon;
			}
			else if(result == "Axe")
			{
				icon.sprite = craftingItemsResultData[1].icon;
			}
			else if (result == "Nail")
			{
				icon.sprite = craftingItemsResultData[2].icon;
			}
			else if (result == "Plank with nails")
			{
				icon.sprite = craftingItemsResultData[4].icon;
			}
			else
			{
				print("No icon");
			}

			return;
		}

		icon.sprite = null;
		itemInstance = null;
		craftButton.interactable = false;
		return;
    }

	public void ChangeSlotToActive(ItemInstance item)
	{
		//itemInstance = item;
		icon.sprite = item.sprite;
		craftButton.interactable = true;
	}

	public void ChangeSlotToUnactive()
	{
		icon.sprite = null;
		itemInstance = null;
		craftButton.interactable = false;
	}

	private string WhatIsTheResult()
	{
		InventoryItemData item1 = craftingItemsResult[0].itemType;
		InventoryItemData item2 = craftingItemsResult[1].itemType;

		if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Wood)
		{
			return "Wooden plank";
		}
		else if (item1.type == InventoryItemData.ItemType.Wood && item2.type == InventoryItemData.ItemType.Rock)
		{
			return "Axe";
		}
		else if (item1.type == InventoryItemData.ItemType.Iron && item2.type == InventoryItemData.ItemType.Iron)
		{
			return "Nail";
		}
		else if (item1.type == InventoryItemData.ItemType.Plank && item2.type == InventoryItemData.ItemType.Nail)
		{
			return "Plank with nails";
		}
		else
		{
			return "No such combination!";
		}
	}
}
