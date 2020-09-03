using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu]
public class EnemyInventoryList : ScriptableObject
{
    public List<Items> inventory;

    public Items GetItemByIdAndDeleteFromInventory(int id,Items noItem)
    {
        Items item = inventory[id];

        inventory[id] = noItem;
        return item;

    }

    public int CountItemsInInventory()
    {
        return inventory.Count(x => x.GetType() != typeof(NoItem));
    }
}
