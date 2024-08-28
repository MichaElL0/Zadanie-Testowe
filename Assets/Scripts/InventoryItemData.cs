using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public Sprite icon;
    public ItemType type;
    public GameObject prefab;

    public enum ItemType
    {
        Rock,
        Wood,
        Iron,
        Tool,
        Nail,
        Plank
    }
}
