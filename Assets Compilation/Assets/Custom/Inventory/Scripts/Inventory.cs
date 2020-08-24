using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Inventory : MonoBehaviour
{

    public GameObject InventoryPanel;

    public GameObject EquipmentUI;

    public static Inventory instance;

    public InventoryList inventoryList;

    public  int index = 0;

    public void updatePanelSlots()
    {
        
        foreach (Transform child in InventoryPanel.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inventoryList.inventoryItems.Count)
            {
                //Debug.Log("slot "+index);
                slot.stackItem = inventoryList.inventoryItems[index];
                //Debug.Log("asd " + slot.item.itemName);

                }
            else
            {
                //  Debug.Log("slet slot " + index);
                NoItem item = new NoItem();
                InventoryStackItems inventoryStackItem = new InventoryStackItems()
                {
                    item = item,
                    stack = 0
                };
                slot.stackItem = inventoryStackItem;
            }

            slot.updateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
        index = 0;
      
    }
    void Start()
    {
        instance = this;
        updatePanelSlots();
    }

    public bool Add(Items item)
    {
        
        if (inventoryList.inventoryItems.Count < 20)
        {
            if(inventoryList.inventoryItems.Exists(x => x.item.itemName == item.itemName && x.item.stackLimit > x.stack))
            {
                inventoryList.inventoryItems.Find(x => x.item.itemName == item.itemName && x.item.stackLimit > x.stack).stack++;

            }
            else
            {
                InventoryStackItems inventoryStackItem = new InventoryStackItems()
                {
                    item = item,
                    stack = 1
                };
                Undo.RecordObject(inventoryList, "new item");
                inventoryList.inventoryItems.Add(inventoryStackItem);

            }

            updatePanelSlots();

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
        updatePanelSlots();
    }
}