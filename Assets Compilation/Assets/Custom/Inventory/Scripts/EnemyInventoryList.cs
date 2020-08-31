using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyInventoryList : ScriptableObject
{
    public List<Items> inventory;

    public Items GetItemByIdAndDeleteFromInventory(int id)
    {
        Items item = inventory[id];
        NoItem noItem = new NoItem();
        inventory[id] = noItem;
        return item;

    }
}
