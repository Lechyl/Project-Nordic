using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public InventoryStackItems stackItem;
    
    void Start()
    {
      //  updateInfo();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!string.IsNullOrEmpty(stackItem.item.itemName))
        {
            Inventory.instance.ChangeTooltipText(stackItem.item);

            Inventory.instance.ShowTooltip(transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Inventory.instance.HideTooltip();

    }

    public void UpdateInfo()
    {
        Text displayText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Image displayImage = transform.GetChild(0).GetChild(1).GetComponent<Image>();
        TextMeshProUGUI displayStack = transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        //TextMeshPro displayStack = transform.GetChild(2).GetComponent<TextMeshPro>();
        // Text displayText = transform.Find("Text").GetComponent<Text>();
        // Image displayImage = transform.Find("Image").GetComponent<Image>();
        if (!string.IsNullOrEmpty(stackItem.item.itemName))
        {

            displayText.text = stackItem.item.itemName;
            displayStack.text = stackItem.stack.ToString();
            displayImage.sprite = stackItem.item.icon;
            displayImage.color = Color.white;
        }
        else
        {
            displayText.text = "";
            displayStack.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }
    
    }


}
