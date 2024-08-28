using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
	public static CraftingSystem instance;

	public List<ItemInstance> craftingItems;
	public int inventorySpace = 2;

	private void Awake()
	{
		instance = this;

		craftingItems = new List<ItemInstance>();
	}

	public bool UseItem(ItemInstance item)
	{
		for (int i = 0; i < craftingItems.Count; i++)
		{
			if (craftingItems[i] == null)
			{
				craftingItems[i] = item;
				return true;
			}
		}

		if (craftingItems.Count < inventorySpace)
		{
			craftingItems.Add(item);
			InventoryUI.instance.UpdateCraftingUI(item);
			return true;
		}
		
		Debug.Log("Crafting is Full!");
		return false;

	}
}
