using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CraftingResultSystem : MonoBehaviour
{
	public static CraftingResultSystem instance;

	public Image icon;
	public Button craftButton;
	ItemInstance itemInstance;

	[Header("Crafting items")]
	public List<ItemInstance> craftingItemsResult;
	public List<InventoryItemData> craftingItemsResultData;

	private Dictionary<InventoryItemData, Sprite> craftingResultSprites;

	public static event Action onCraftItem;
	public UnityEvent onCraftItemEventSuccess;
	public UnityEvent onCraftItemEventUnsuccess;

	

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

				if(AttemptCrafting(result.chanceOfCrafting))
				{
					InventorySystem.instance.AddItem(result);
					onCraftItemEventSuccess.Invoke();
					print("Success!");
					CraftingResultClear();
				}
				else
				{
					CraftingResultClear();
					onCraftItemEventUnsuccess.Invoke();
					print("No success!");
				}
			}
			
		}
		else
		{
			print("No space to craft!");
		}

		ChangeSlotToUnactive();
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
			ChangeSlotToUnactive();
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

	void CraftingResultClear()
	{
		craftingItemsResult.Clear();
		CraftingSystem.instance.craftingItems.Clear();
		icon.sprite = null;
	}

	private InventoryItemData WhatIsTheResult()
	{
		InventoryItemData item1 = craftingItemsResult[0].itemType;
		InventoryItemData item2 = craftingItemsResult[1].itemType;

		switch(item1.type, item2.type)
		{
			case(InventoryItemData.ItemType.Wood, InventoryItemData.ItemType.Wood):
				return craftingItemsResultData[0];
			case (InventoryItemData.ItemType.Wood, InventoryItemData.ItemType.Rock):
			case (InventoryItemData.ItemType.Rock, InventoryItemData.ItemType.Wood):
				return craftingItemsResultData[1];
			case (InventoryItemData.ItemType.Iron, InventoryItemData.ItemType.Iron):
				return craftingItemsResultData[2];
			case (InventoryItemData.ItemType.Plank, InventoryItemData.ItemType.Nail):
			case (InventoryItemData.ItemType.Nail, InventoryItemData.ItemType.Plank):
				return craftingItemsResultData[3];
		}
		ChangeSlotToUnactive();
		return null;
	}

	public bool AttemptCrafting(int successRate)
	{
		if (successRate < 0 || successRate > 100)
		{
			throw new ArgumentOutOfRangeException(nameof(successRate), "Success rate must be between 0 and 100.");
		}

		int chance = UnityEngine.Random.Range(0, 100);

		print("is succesfull? " + (chance < successRate));

		return chance < successRate;
	}
}
