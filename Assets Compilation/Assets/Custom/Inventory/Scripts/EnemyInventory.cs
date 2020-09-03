using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class EnemyInventory : MonoBehaviour
{

    public GameObject InventoryPanel;


    public static EnemyInventory instance;

    public EnemyInventoryList inventoryList;

    public int index = 0;

    public void UpdatePanelSlots()
    {

        foreach (Transform child in InventoryPanel.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inventoryList.inventory.Count)
            {
                //Debug.Log("slot "+index);
                InventoryStackItems stackItem = new InventoryStackItems()
                {
                   item = inventoryList.inventory[index],
                   stack = 1
                };
                slot.stackItem = stackItem;
                //Debug.Log("asd " + slot.item.itemName);

            }
            else
            {
                //  Debug.Log("slet slot " + index);

                //  slot.stackItem = inventoryStackItem;
            }

            slot.UpdateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
        index = 0;

    }

    //here we instantiate inventory with saved data
    //but for Demo we recreate inventory
    void ResetInventoryPanel()
    {
        inventoryList.inventory.Clear();

gameObject.AddComponent<NoItem>();
        NoItem item = gameObject.AddComponent<NoItem>();

        for (int i = 0; i < 20; i++)
        {
            inventoryList.inventory.Add(item);

        }



    }
    void Start()
    {
        instance = this;
        ResetInventoryPanel();
        UpdatePanelSlots();
    }

    public bool ReplaceInventory(List<Items> newInventory)
    {
        ResetInventoryPanel();
        if (inventoryList.inventory.Count == 20 && inventoryList.CountItemsInInventory() <= 20)
        {
            //if (inventoryList.inventory.Exists(x => x.itemName == item.itemName && x.item.stackLimit > x.stack))
           // {
             //   inventoryList.inventory.Find(x => x.item.itemName == item.itemName && x.item.stackLimit > x.stack).stack++;

            //}
            //else
           // {
               // InventoryStackItems inventoryStackItem = new InventoryStackItems()
                //{
                  //  item = item,
                   // stack = 1
               // };

            foreach(var item in newInventory)
            {
                Undo.RecordObject(item, "new item");

                inventoryList.inventory[inventoryList.inventory.FindIndex(x => x.itemName == "")] = item;

            }
            //inventoryList.inventory = newInventory;

            //}

            UpdatePanelSlots();

            return true;
        }
        else
        {
            return false;
        }
    }
    public void Remove(Items item)
    {
        //  inventoryList.inventoryItems.Remove(item);
        UpdatePanelSlots();
    }

    public Items GetItemFromInventory(int id)
    {
        return inventoryList.inventory[id];

 
    }
    public void DeleteItemFromInventory(int id)
    {
        NoItem noitem = gameObject.AddComponent<NoItem>();
        inventoryList.inventory[id] = noitem;

        UpdatePanelSlots();
    }
}