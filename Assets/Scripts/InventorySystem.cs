using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventorySystem : MonoBehaviour
{
	public static InventorySystem instance;

	public List<ItemInstance> inventoryItems;
	public int inventorySpace = 14;

	public Transform dropPoint;

	private void Awake()
	{
		instance = this;

		inventoryItems = new List<ItemInstance>();
	}

	public bool AddItem(InventoryItemData item)
	{
		ItemInstance itemInstance = new ItemInstance(item);

		for (int i = 0; i < inventoryItems.Count; i++)
		{
			if (inventoryItems[i] == null)
			{
				inventoryItems[i] = itemInstance;
				return true;
			}
		}

		if (inventoryItems.Count < inventorySpace)
		{
			inventoryItems.Add(itemInstance);
			InventoryUI.instance.UpdateUI(itemInstance);
			return true;
		}

		Debug.Log("Inventory is Full!");
		return false;

	}

	public void Remove(ItemInstance refItem)
	{
		inventoryItems.Remove(refItem);
		print("Remove item");
		Instantiate(refItem.prefab, dropPoint.position, Quaternion.identity);
		
	}


}
