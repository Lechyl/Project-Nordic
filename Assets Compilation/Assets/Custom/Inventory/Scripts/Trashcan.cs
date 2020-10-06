using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trashcan : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public InventoryStackItems targetItem;
    private Image icon;
    public Sprite t_open;
    public Sprite t_close;

    private void Start()
    {
        icon = transform.GetComponent<Image>();
        icon.sprite = t_close;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        icon.sprite = t_open;
        Debug.Log("MouseOverTrashCan");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        icon.sprite = t_close;
        Debug.Log("MouseExitTrashCan");
    }

    public void OnDrop(PointerEventData eventData)
    {
        targetItem = eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem;

        if (eventData.pointerDrag != null)
        {
            Inventory.instance.Remove(targetItem);
            Debug.Log("Item removed");
        }
    }
}
