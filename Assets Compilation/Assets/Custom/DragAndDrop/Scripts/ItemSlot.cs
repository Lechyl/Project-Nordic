using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {

        Debug.Log("gamer " + this.gameObject.GetComponent<InventorySlotController>().stackItem.item.itemName); 
        Debug.Log("test test"+eventData.pointerDrag.GetComponentInChildren<Text>().text);
        Debug.Log("and the name is : " + this.transform.name);


        if (eventData.pointerDrag != null)
        {
        Debug.Log("and his name was : " + this.gameObject.GetComponent<InventorySlotController>().stackItem.item.itemName);
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

            Inventory.instance.inventoryList.Replace(first, second);

            //Debug.Log("the child name is " + this.transform.GetChild(0).GetChild(0).GetComponent<Text>().text) ;
            
            string oldtext = transform.GetChild(0).GetChild(0).GetComponent<Text>().text;
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

            eventData.pointerDrag.transform.rotation = this.transform.rotation;
            eventData.pointerDrag.transform.localPosition = Vector3.zero;
            eventData.pointerDrag.transform.localScale = Vector3.one;
            //eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 



        }
    }
}
