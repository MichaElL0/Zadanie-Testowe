using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;

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
}
