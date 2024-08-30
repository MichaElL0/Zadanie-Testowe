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
    ItemInstance itemInstance;

    public static event Action OnDrop;
    public static event Action OnItemCraft;

    public void ChangeSlotToActive(ItemInstance item)
    {
        itemInstance = item;
		icon.sprite = item.sprite;
        dropButton.interactable = true;
        if(itemInstance.itemType.type != InventoryItemData.ItemType.Tool)
        {
            useButton.interactable = true;
            
        }
        else
        {
			useButton.interactable = false;
		}
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
        OnDrop?.Invoke();

        if (itemInstance != null)
        {
            InventorySystem.instance.Drop(itemInstance);
            ChangeSlotToUnactive();
        }

    }

    public void UseItemInCrafting()
    {
        if(CraftingSystem.instance.craftingItems.Count < 2)
        {
			InventorySystem.instance.MoveToCrafting(itemInstance);
			ChangeSlotToUnactive();
            OnItemCraft?.Invoke();
		}
        else
        {
            Debug.LogError("Crafting is full!");
        }
    }
}
