using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
	public static InventorySystem instance;
	public List<InventoryItem> inventory;
	public int inventorySpace = 21;

	private void Awake()
	{
		instance = this;

		inventory = new List<InventoryItem>();
	}

	public bool Add(InventoryItemData refItem)
	{
		if(inventory.Count < inventorySpace)
		{
			InventoryItem newItem = new InventoryItem(refItem);
			inventory.Add(new InventoryItem(refItem));

			InventoryUI.instance.UpdateUI(newItem);
			return true;
			
		}
		else 
		{
			Debug.Log("Inventory is Full!");
			return false;
		}

		
	}

	public void Remove(InventoryItem refItem)
	{
		inventory.Remove(refItem);
		print("Remove item");
		
	}


}
