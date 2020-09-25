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

    public GameObject equipmentUI;

    public GameObject hotbarUI;

    public static Inventory instance;

    public InventoryList inventoryList;

    public  int index = 0;

    public EquipmentList equipmentList;

    public HotbarList hotbarList;

    public GameObject tooltip;

    public void UpdatePanelSlots()
    {
        index = 0;

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

              //  slot.stackItem = inventoryStackItem;
            }

            slot.UpdateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
      
    }

    //here we instantiate inventory with saved data
    //but for Demo we recreate inventory
    void InstantiateInventory()
    {
        inventoryList.inventoryItems.Clear();


        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItem = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };
        for (int i = 0; i < 20; i++)
        {
            inventoryList.inventoryItems.Add(inventoryStackItem);

        }

    }

    void InstantiateHotbar()
    {
        hotbarList.hotbarList.Clear();


        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItem = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };
        for (int i = 0; i < 3; i++)
        {

            hotbarList.hotbarList.Add(inventoryStackItem);

        }
    }
   public void UpdateHotbarSlots()
    {
        index = 0;

        foreach (Transform child in hotbarUI.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < hotbarList.hotbarList.Count)
            {
                //Debug.Log("slot "+index);
                slot.stackItem = hotbarList.hotbarList[index];
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
    }
    void Start()
    {
        instance = this;
        
        InstantiateInventory();
        UpdatePanelSlots();
        
        InstantiateHotbar();
        UpdateHotbarSlots();

        InstantiateEquipment();
        UpdateEquiptmentSlot(typeof(NoItem));

    }


    public bool Add(Items item)
    {
        //EditorUtility.SetDirty(item);

        if (inventoryList.inventoryItems.Count == 20 && inventoryList.CountItemsInInventory() < 20 && item.GetType() != typeof(NoItem))
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
                inventoryList.inventoryItems[inventoryList.inventoryItems.FindIndex(x => x.stack == 0)] = inventoryStackItem;

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

    //################################################################################################### EQUIPMENT ####################################################################################


        public void UpdateEquiptmentSlot(System.Type type)
    {


        foreach (Transform child in equipmentUI.transform.GetChild(0))
        {

            EquipmentSlotController slot = child.GetComponent<EquipmentSlotController>();

            if (slot.name == "HeadSlot" && type == typeof(Head))
            {
                InventoryStackItems newItem = new InventoryStackItems()
                {
                    item = equipmentList.head,
                    stack = 1
                };
                slot.stackItem = newItem;


            }
            else if (slot.name == "BreastplateSlot" && type == typeof(Breastplate))
            {
                InventoryStackItems newItem = new InventoryStackItems()
                {
                    item = equipmentList.breastplate,
                    stack = 1
                };
                slot.stackItem = newItem;

            }
            else if (slot.name == "LegsSlot" && type == typeof(Legs))
            {

                slot.stackItem.item = equipmentList.legs;

            }
            else if (slot.name == "BootsSlot" && type == typeof(Boots))
            {

                slot.stackItem.item = equipmentList.boots;
                slot.stackItem.stack = 1;
            }
            else if (slot.name == "WeaponsSlot" && type == typeof(Wepons))
            {

                slot.stackItem.item = equipmentList.Wepons;
                slot.stackItem.stack = 1;
            }
            else if (slot.name == "SheldSlot" && type == typeof(Wepons))
            {

                slot.stackItem.item = equipmentList.Wepons;
                slot.stackItem.stack = 1;
            }
            else if (type == typeof(NoItem))
            {
                Items item = new NoItem();
                slot.stackItem.item = item;
                slot.stackItem.stack = 0;

            }

            slot.UpdateInfo();
        }
    }

    void InstantiateEquipment()
    {
        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItems = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };


        equipmentList.head = item;
        equipmentList.breastplate = item;
        equipmentList.legs = item;
        equipmentList.boots = item;
        equipmentList.Wepons = item;

    }


    public void ReplaceEquiptment(ReplaceEquiptment to, ReplaceItem from)
    {

        inventoryList.inventoryItems[from.slot] = to.item;

        if (to.item.item.GetType() != typeof(NoItem))
            inventoryList.inventoryItems[from.slot].stack = 4;




        if (to.type == typeof(Head))
        {
            equipmentList.head = from.item.item;




        }
        else if (to.type == typeof(Breastplate))
        {
            equipmentList.breastplate = from.item.item;
        }
        else if (to.type == typeof(Legs))
        {
            equipmentList.legs = from.item.item;

        }
        else if (to.type == typeof(Boots))
        {
            equipmentList.boots = from.item.item;

        }
        else if (to.type == typeof(Wepons))
        {
            equipmentList.Wepons = from.item.item;

        }

        UpdateEquiptmentSlot(from.item.item.GetType());
        UpdatePanelSlots();


    }


    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }
}