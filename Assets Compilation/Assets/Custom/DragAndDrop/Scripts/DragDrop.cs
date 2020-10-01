using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
{
    private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private EquipmentList equipmentList; 



    private void Awake()
    {
        canvas = this.GetComponentInParent<Canvas>();
        rectTransform = this.GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        equipmentList = Inventory.instance.equipmentList; 
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f; 
        canvasGroup.blocksRaycasts = false; 
    }
     
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.transform.localPosition = Vector3.zero;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Right == eventData.button)
        {

            ReplaceItem secondInventoryItem = new ReplaceItem()
            {
                item = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem,
                slot = int.Parse(eventData.pointerDrag.transform.parent.name)
            };

            


            if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Head))
            {

                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    //equiptment 
                    item = eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(0).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equiptment text 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equiptment sprite 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equiptment color 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;
                
               

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Breastplate))
            {
                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(1).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };

                // get equiptment text 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equiptment sprite 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equiptment color 
                eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Legs))
            {
                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(2).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(2).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Boots))
            {

                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(3).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(3).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(3).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(3).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Wepons))
            {

                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.GetChild(7).GetChild(0).GetChild(4).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(4).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(4).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.GetChild(7).GetChild(0).GetChild(4).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }


        }

    }
}



/*
if(eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Healing))
{
    if(!eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.name == "healingpotivf")
    {

    }
}
*/