using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button button;
    [SerializeField]ItemInstance itemInstance;

    public void ChangeSlotToActive(ItemInstance item)
    {
        itemInstance = item;
		icon.sprite = item.sprite;
        button.interactable = true;
    }

	public void ChangeSlotToUnactive()
	{
        icon.sprite = null;
		button.interactable = false;
	}

    public void RemoveItem()
    {
        if(itemInstance != null)
        {
            InventorySystem.instance.Remove(itemInstance);
        }
    }
}
