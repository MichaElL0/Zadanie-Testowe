using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public static InventoryUI instance;

    public GameObject inventoryPanel;
	public List<GameObject> inventoryItems;

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

	public void UpdateUI()
	{
		print("Update UI");
	}

}
