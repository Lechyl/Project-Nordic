using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class InventoryList : ScriptableObject
{
    public List<InventoryStackItems> inventoryItems;

    public void Replace(ReplaceItem target, ReplaceItem you)
    {
        inventoryItems[you.slot] = target.item;
        inventoryItems[target.slot] = you.item;

    }

}
