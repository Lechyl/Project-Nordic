using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class EnemyInventory : MonoBehaviour
{

    public GameObject enemyInventoryUI;


    public static EnemyInventory instance;

    public EnemyInventoryList inventoryList;

    public int index = 0;

    public void UpdatePanelSlots()
    {

        foreach (Transform child in enemyInventoryUI.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inventoryList.inventory.Count)
            {
                InventoryStackItems stackItem = new InventoryStackItems()
                {
                   item = inventoryList.inventory[index],
                   stack = 1
                };
                slot.stackItem = stackItem;

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

        
        NoItem item = new NoItem();

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
         

            foreach(var item in newInventory)
            {

                inventoryList.inventory[inventoryList.inventory.FindIndex(x => x.itemName == "")] = item;

            }


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
        UpdatePanelSlots();
    }

    public Items GetItemFromInventory(int id)
    {
        return inventoryList.inventory[id];

 
    }
    public void DeleteItemFromInventory(int id)
    {
        NoItem noitem = new NoItem();
        inventoryList.inventory[id] = noitem;

        UpdatePanelSlots();
    }
}