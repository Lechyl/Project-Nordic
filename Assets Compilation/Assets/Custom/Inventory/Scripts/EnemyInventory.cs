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
    void InstantiateInventory()
    {
        inventoryList.inventory.Clear();


        NoItem item = gameObject.AddComponent<NoItem>();

        for (int i = 0; i < 20; i++)
        {
            inventoryList.inventory.Add(item);

        }



    }
    void Start()
    {
        instance = this;
        InstantiateInventory();
        UpdatePanelSlots();
    }

    public bool Add(Items item)
    {

        if (inventoryList.inventory.Count == 20)
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
                Undo.RecordObject(inventoryList, "new item");
                inventoryList.inventory[inventoryList.inventory.FindIndex(x => x.itemName == "")] = item;

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
}