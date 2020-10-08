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
    public Transform rightHand;



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
                    item = eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(0).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equiptment text 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(0).GetChild(0).GetChild(0).transform.GetComponent<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equiptment sprite 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equiptment color 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(0).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;
                
               

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Breastplate))
            {
                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(1).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };

                // get equiptment text 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(1).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equiptment sprite 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equiptment color 
                eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(1).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Legs))
            {
                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(2).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(2).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(2).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Boots))
            {

                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(3).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(3).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(3).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(3).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);

            }

            else if (eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType() == typeof(Weapons))
            {

                ReplaceEquiptment firstInventoryItem = new ReplaceEquiptment()
                {
                    item = eventData.pointerPress.transform.root.Find("equipmentUI").GetChild(0).GetChild(4).gameObject.GetComponent<EquipmentSlotController>().stackItem,
                    type = eventData.pointerDrag.transform.parent.gameObject.GetComponent<InventorySlotController>().stackItem.item.GetType()
                };
                // get equipment text 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(4).GetChild(0).GetChild(0).transform.GetComponentInChildren<Text>().text = eventData.pointerPress.transform.GetChild(0).GetComponent<Text>().text;
                // get equipment sprite 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(4).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().sprite = eventData.pointerPress.transform.GetComponentInChildren<Image>().sprite;
                // get equipment color 
                eventData.pointerPress.transform.parent.parent.parent.Find("equipmentUI").GetChild(0).GetChild(4).GetChild(0).GetChild(1).transform.GetComponentInChildren<Image>().color = eventData.pointerPress.transform.GetComponentInChildren<Image>().color;

                Inventory.instance.ReplaceEquiptment(firstInventoryItem, secondInventoryItem);




                //I might waant to change GetComponent<Wepons>() to conparetag instead because It uses less ressources

                //set trigger of weapon to true and false

                // disable current equipt weapon 
                if (rightHand.childCount > 0)
                {
                    //Detatch item in Players right hand and reset items values to gamemode
                    rightHand.GetChild(0).position = new Vector3(rightHand.position.x, 1, rightHand.position.z);

                    rightHand.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
                    rightHand.GetChild(0).gameObject.GetComponent<Collider>().enabled = false;

                    rightHand.DetachChildren(); 
                    
                }


                //Attach Weapon on Players right hand

                secondInventoryItem.item.item.tag = "PlayerWeapon";
                // Set Position for Item  to be equal to Righthand
                secondInventoryItem.item.item.gameObject.transform.position = rightHand.transform.position;
                // equip Weapon to Player righthand
                secondInventoryItem.item.item.gameObject.transform.SetParent(rightHand.transform);
                //enable mesh renderer
                secondInventoryItem.item.item.gameObject.GetComponent<MeshRenderer>().enabled = true;
                //Rotate Weapon
                secondInventoryItem.item.item.gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                secondInventoryItem.item.item.gameObject.transform.localPosition = new Vector3(0, 0, 1);


                Instantiate(secondInventoryItem.item.item.gameObject);



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