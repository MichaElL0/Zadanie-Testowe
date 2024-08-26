using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
	public static InventorySystem instance;
	public List<InventoryItemData> inventory;
	int inventorySpace = 21;

	private void Awake()
	{
		instance = this;

		inventory = new List<InventoryItemData>();
	}

	public bool Add(InventoryItemData refItem)
	{
		if(inventory.Count < inventorySpace)
		{
			inventory.Add(refItem);

			InventoryUI.instance.UpdateUI(refItem);
			return true;
			
		}
		else 
		{
			Debug.Log("Inventory is Full!");
			return false;
		}

		
	}

	public void Remove(InventoryItemData refItem)
	{
		print("Remove item");
		inventory.Remove(refItem);
	}


}
