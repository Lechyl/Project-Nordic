using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class HotbarList : ScriptableObject
{
    public List<InventoryStackItems> hotbarList = new List<InventoryStackItems>();


    public void AddItemFromInventory(ReplaceItem hotbarItem, ReplaceItem invItem)
    {
        hotbarList[hotbarItem.slot] = invItem.item;
    }

    public void ReplaceHotbarItems(ReplaceItem item1, ReplaceItem item2)
    {
        hotbarList[item1.slot] = item2.item;
        hotbarList[item2.slot] = item1.item;

    }

    public void UseConsumableItem(int slot)
    {
        hotbarList[slot].stack--;
        Debug.Log("Consume");
        if (hotbarList[slot].stack < 1)
        {
            InventoryStackItems stackItem = new InventoryStackItems()
            {
                item = new NoItem(),
                stack = 0
            };
            hotbarList[slot] = stackItem;
        }
    }

}
