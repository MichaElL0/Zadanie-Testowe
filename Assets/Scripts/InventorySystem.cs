using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
	public static InventorySystem instance;
	public List<InventoryItemData> inventory;

	private void Awake()
	{
		instance = this;

		inventory = new List<InventoryItemData>();
	}

	public void Add(InventoryItemData refItem)
	{
		//InventoryItem newItem = new InventoryItem(refItem);
		inventory.Add(refItem);
		print("--");
	}

	//public void Remove(InventoryItem refItem)
	//{
	//	print("Remove item");
	//	inventory.Remove(refItem);
	//}

	
}
