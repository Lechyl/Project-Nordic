using Assets.Custom.items.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HotBarSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        //Check if eventData is empty and if Item is a Subclass of Consumable
        if (eventData.pointerDrag != null && eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType().BaseType == typeof(Consumable))
        {
            //The Item from Hotbar
            ReplaceItem hotbarItem = new ReplaceItem()
            {

                item = this.gameObject.GetComponent<InventorySlotController>().stackItem,
                slot = int.Parse(this.transform.name)

            };



            //Check if items from hotbar are switching
            if (eventData.pointerDrag.HasComponent<HotBarDragDrop>())
            {
                ReplaceItem hotbarItem2 = new ReplaceItem()
                {

                    item = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem,
                    slot = int.Parse(eventData.pointerDrag.transform.parent.name)

                };


                Inventory.instance.hotbarList.ReplaceHotbarItems(hotbarItem, hotbarItem2);

                Inventory.instance.UpdateHotbarSlots();


                eventData.pointerDrag.transform.rotation = this.transform.rotation;
                eventData.pointerDrag.transform.localPosition = Vector3.zero;
                eventData.pointerDrag.transform.localScale = Vector3.one;
            }
            else
            {

                //The item from inventory

                ReplaceItem invItem = new ReplaceItem()
                {

                    item = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem,
                    slot = int.Parse(eventData.pointerDrag.transform.parent.name)

                };
                //
                 TextMeshProUGUI displayText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
                 displayText.text = invItem.item.stack.ToString();


                //replace item in inventorylist
                Inventory.instance.inventoryList.AddItemFromHotbbar(invItem, hotbarItem);
                //replace item in hotbarlist    
                Inventory.instance.hotbarList.AddItemFromInventory(hotbarItem, invItem);

                Inventory.instance.UpdatePanelSlots();
                Inventory.instance.UpdateHotbarSlots();

                /*   string oldtext = transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                   Sprite oldImg = transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                   Color oldColor = transform.GetChild(0).GetChild(1).GetComponent<Image>().color;
                   InventoryStackItems stackitem = this.gameObject.GetComponent<InventorySlotController>().stackItem;


                   //Override this Gameobject StackItem
                   transform.GetChild(0).GetChild(0).GetComponent<Text>().text = eventData.pointerDrag.GetComponentInChildren<Text>().text;
                   transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = eventData.pointerDrag.GetComponentInChildren<Image>().sprite;
                   transform.GetChild(0).GetChild(1).GetComponent<Image>().color = eventData.pointerDrag.GetComponentInChildren<Image>().color;
                   this.gameObject.GetComponent<InventorySlotController>().stackItem = eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem;

                   //Override The drag gameobject
                   eventData.pointerDrag.GetComponentInChildren<Text>().text = oldtext;
                   eventData.pointerDrag.GetComponentInChildren<Image>().sprite = oldImg;
                   eventData.pointerDrag.GetComponentInChildren<Image>().color = oldColor;
                   eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem = stackitem;
                       */
                eventData.pointerDrag.transform.rotation = this.transform.rotation;
                eventData.pointerDrag.transform.localPosition = Vector3.zero;
                eventData.pointerDrag.transform.localScale = Vector3.one;
            }

        }

    }
}
