using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EquiptmentSlot : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("test test"); 
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (transform.parent.GetComponent<InventorySlotController>().stackItem.item.GetType() != typeof(NoItem))
            {

                NoItem noneitem = new NoItem();
                InventoryStackItems noitem = new InventoryStackItems()
                {
                    item = noneitem,
                    stack = 0
                };


                Inventory.instance.Add(transform.parent.GetComponent<InventorySlotController>().stackItem.item);
                transform.parent.GetComponent<InventorySlotController>().stackItem = noitem;

                //eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text = "";
                transform.GetChild(0).GetComponent<Text>().text = "";
                transform.GetChild(1).GetComponent<Image>().sprite = null;
                transform.GetChild(1).GetComponent<Image>().color = Color.clear;


            }



        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
