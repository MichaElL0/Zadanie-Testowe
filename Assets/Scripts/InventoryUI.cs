using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public GameObject inventoryPanel;
	public List<InventorySlot> inventoryItems;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
			return;
		}
		instance = this;
	}

	// Update is called once per frame
	void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab) && inventoryPanel.activeInHierarchy == false) 
        {
            inventoryPanel.SetActive(true);
			Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
		}
        else if(Input.GetKeyUp(KeyCode.Tab) && inventoryPanel.activeInHierarchy == true)
        {
			inventoryPanel.SetActive(false);
			Cursor.lockState = CursorLockMode.Locked;
			Time.timeScale = 1f;
		}
    }

	public void UpdateUI(InventoryItem item)
	{
		for(int i = 0; i < inventoryItems.Count; i++)
		{
			if(inventoryItems[i].icon.sprite == null)
			{
				inventoryItems[i].ChangeSlotToActive(item);
				return;
			}

		}
	}

}
