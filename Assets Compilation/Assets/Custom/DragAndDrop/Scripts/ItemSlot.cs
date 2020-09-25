using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {


        //eventData.pointerDrag.
        ReplaceItem first = new ReplaceItem()
        {

            item = this.gameObject.GetComponent<InventorySlotController>().stackItem,
            slot = int.Parse(this.transform.name)

        };



        ReplaceItem second = new ReplaceItem()
        {
            //slot = int.Parse(this.gameObject.GetComponentInParent<InventorySlotController>().name)

            item = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem,
            slot = int.Parse(eventData.pointerDrag.transform.parent.name)

        };

        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.HasComponent<HotBarDragDrop>())
            {
                if(this.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType().BaseType == typeof(Consumable) || this.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(NoItem))
                {
                    //replace item from inventory to hotbar and verse vera.
                    Inventory.instance.inventoryList.AddItemFromHotbbar(first, second);
                    Inventory.instance.hotbarList.AddItemFromInventory(second, first);

                    //Update UI
                    Inventory.instance.UpdatePanelSlots();
                    Inventory.instance.UpdateHotbarSlots();


                    eventData.pointerDrag.transform.rotation = this.transform.rotation;
                    eventData.pointerDrag.transform.localPosition = Vector3.zero;
                    eventData.pointerDrag.transform.localScale = Vector3.one;
                }
            }
            else
            {




                Inventory.instance.inventoryList.Replace(first, second);


                //Update Only UI Slot for Affected Items/slots

                string oldtext = transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
                Sprite oldImg = transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite;
                Color oldColor = transform.GetChild(0).GetChild(1).GetComponent<Image>().color;
                string oldstack = transform.GetChild(2).GetComponent<TextMeshProUGUI>().text;
                InventoryStackItems stackitem = this.gameObject.GetComponent<InventorySlotController>().stackItem;

                Debug.Log(eventData.pointerDrag.name);
                //Override this Gameobject StackItem
                transform.GetChild(0).GetChild(0).GetComponent<Text>().text = eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text;
                transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = eventData.pointerDrag.GetComponentInChildren<Image>().sprite;
                transform.GetChild(0).GetChild(1).GetComponent<Image>().color = eventData.pointerDrag.GetComponentInChildren<Image>().color;
                transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = eventData.pointerDrag.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().text;
                this.gameObject.GetComponent<InventorySlotController>().stackItem = eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem;

                //Override The drag gameobject
                eventData.pointerDrag.transform.GetChild(0).GetComponent<Text>().text = oldtext;
                eventData.pointerDrag.GetComponentInChildren<Image>().sprite = oldImg;
                eventData.pointerDrag.GetComponentInChildren<Image>().color = oldColor;
                eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem = stackitem;
                eventData.pointerDrag.transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>().text = oldstack;


                eventData.pointerDrag.transform.rotation = this.transform.rotation;
                eventData.pointerDrag.transform.localPosition = Vector3.zero;
                eventData.pointerDrag.transform.localScale = Vector3.one;


            }


        }
    }


}
