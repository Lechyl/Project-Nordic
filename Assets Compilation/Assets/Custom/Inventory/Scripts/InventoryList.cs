using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class InventoryList : ScriptableObject
{
    public List<InventoryStackItems> inventoryItems;

    public void Replace(ReplaceItem to, ReplaceItem from)
    {
        inventoryItems[from.slot] = to.item;
        inventoryItems[to.slot] = from.item;

    }

    public int CountItemsInInventory()
    {
        return inventoryItems.Count(x => x.item.GetType() != typeof(NoItem));
    }


}
