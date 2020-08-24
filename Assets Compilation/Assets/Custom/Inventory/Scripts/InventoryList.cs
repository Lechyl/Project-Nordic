using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class InventoryList : ScriptableObject
{
    public List<InventoryStackItems> inventoryItems;
}
