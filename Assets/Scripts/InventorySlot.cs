using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button dropButton;
    public Button useButton;
    [SerializeField]ItemInstance itemInstance;

    public static event Action onDrop;
    public static event Action onCraft;

    public void ChangeSlotToActive(ItemInstance item)
    {
        itemInstance = item;
		icon.sprite = item.sprite;
        dropButton.interactable = true;
        useButton.interactable = true;
    }

	public void ChangeSlotToUnactive()
	{
        icon.sprite = null;
        itemInstance = null;
		dropButton.interactable = false;
		useButton.interactable = false;
	}

    public void DropItem()
    {
        onDrop?.Invoke();

        if (itemInstance != null)
        {
            InventorySystem.instance.Remove(itemInstance);
            ChangeSlotToUnactive();
        }

    }

    public void CraftItem()
    {
        onCraft?.Invoke();
    }
}
