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

    public static Inventory instance;

    public InventoryList inventoryList;

    public  int index = 0;

    public EquipmentList equipmentList;

    public void UpdatePanelSlots()
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
        inventoryList.inventoryItems.Clear();


        NoItem item = gameObject.AddComponent<NoItem>();
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
    void Start()
    {
        instance = this;
        InstantiateInventory();
        UpdatePanelSlots();
        InstantiateEquipment();
        UpdateEquiptmentSlot();

    }

    public bool Add(Items item)
    {
        EditorUtility.SetDirty(item);

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
            Debug.Log("items in slot "+inventoryList.CountItemsInInventory());
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

    //################################################################################################### EQUIPMENT ####################################################################################

    public void UpdateEquiptmentSlot()
    {
        // equipmentUI.transform.GetChild(0); 
        Debug.Log("Osd " + inventoryList.inventoryItems[0].item.GetType());

         equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().stackItem.item = equipmentList.head;
         Debug.Log("O1 " + inventoryList.inventoryItems[0].item.GetType());

         equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().UpdateInfo();

         Debug.Log("O2 " + inventoryList.inventoryItems[0].item.GetType());

         equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().stackItem.item = equipmentList.breastplate;
         equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().stackItem.item = equipmentList.legs;
         equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().stackItem.item = equipmentList.boots;
         equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().stackItem.item = equipmentList.Wepons;
         equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().UpdateInfo();
         
    }
        public void UpdateEquiptmentSlot(int i,InventoryStackItems item, System.Type type)
    {
        // equipmentUI.transform.GetChild(0); 
        Debug.Log("Osd " + inventoryList.inventoryItems[0].item.GetType());

        /* equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().stackItem.item = equipmentList.head;
         Debug.Log("O1 " + inventoryList.inventoryItems[0].item.GetType());

         equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().UpdateInfo();

         Debug.Log("O2 " + inventoryList.inventoryItems[0].item.GetType());

         equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().stackItem.item = equipmentList.breastplate;
         equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().stackItem.item = equipmentList.legs;
         equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().stackItem.item = equipmentList.boots;
         equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().UpdateInfo();

         equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().stackItem.item = equipmentList.Wepons;
         equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().UpdateInfo();
         */


        foreach (Transform child in equipmentUI.transform.GetChild(0))
        {
         
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inventoryList.inventoryItems.Count)
            {


                if ( slot.name == "HeadSlot" && type == typeof(Head))
                {

                    slot.stackItem = item;
                    slot.UpdateInfo();

                    break;
                }
                else if (slot.name == "BreastplateSlot" && type == typeof(Breastplate))
                {
                    slot.stackItem = item;
                    slot.UpdateInfo();
                    break;
                }
          

                //Debug.Log("slot "+index);


            }
            else
            {
                //  Debug.Log("slet slot " + index);

                //  slot.stackItem = inventoryStackItem;
            }

            //Update slot[index]'s name and icon

        }
        

        Debug.Log("O "+inventoryList.inventoryItems[0].item.GetType());
    }

    void InstantiateEquipment()
    {
        NoItem item = gameObject.AddComponent<NoItem>();
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
        Debug.Log("Whatsup " + from.item.item.GetType());

        inventoryList.inventoryItems[from.slot] = to.item;

        if (to.item.item.GetType() != typeof(NoItem))
            inventoryList.inventoryItems[from.slot].stack = 4;




        if (to.type == typeof(Head))
        {
            equipmentList.head = from.item.item;
            //equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().stackItem.item = equipmentList.head;
            //equipmentUI.transform.GetChild(0).GetChild(0).GetComponent<InventorySlotController>().UpdateInfo();
            Debug.Log("s " + equipmentList.breastplate.itemName);
            Debug.Log("a " + equipmentList.legs.itemName);
            Debug.Log("d " + equipmentList.boots.itemName);
            Debug.Log("l " + equipmentList.Wepons.itemName);


        }
        else if (to.type == typeof(Breastplate))
        {
            Debug.Log("NOT HERE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            equipmentList.breastplate = from.item.item;
           // equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().stackItem.item = equipmentList.breastplate;
           // equipmentUI.transform.GetChild(0).GetChild(1).GetComponent<InventorySlotController>().UpdateInfo();
        }
        else if (to.type == typeof(Legs))
        {
            equipmentList.legs = from.item.item;
           // equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().stackItem.item = equipmentList.legs;
           // equipmentUI.transform.GetChild(0).GetChild(2).GetComponent<InventorySlotController>().UpdateInfo();
        }
        else if (to.type == typeof(Boots))
        {
            equipmentList.boots = from.item.item;
           // equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().stackItem.item = equipmentList.boots;
            //equipmentUI.transform.GetChild(0).GetChild(3).GetComponent<InventorySlotController>().UpdateInfo();
        }
        else if (to.type == typeof(Wepons))
        {
            equipmentList.Wepons = from.item.item;
            //equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().stackItem.item = equipmentList.Wepons;
          //  equipmentUI.transform.GetChild(0).GetChild(4).GetComponent<InventorySlotController>().UpdateInfo();
        }




        Debug.Log("" + inventoryList.inventoryItems[0].item.GetType());






        Debug.Log("L " + inventoryList.inventoryItems[0].item.GetType());

        UpdateEquiptmentSlot(from.slot,from.item,from.item.item.GetType());
        UpdatePanelSlots();


    }
}