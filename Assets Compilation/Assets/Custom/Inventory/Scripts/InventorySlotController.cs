using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotController : MonoBehaviour
{
    public InventoryStackItems stackItem;
    
    void Start()
    {
      //  updateInfo();
    }


    public void UpdateInfo()
    {
        Text displayText = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Image displayImage = transform.GetChild(0).GetChild(1).GetComponent<Image>();
       // Text displayText = transform.Find("Text").GetComponent<Text>();
       // Image displayImage = transform.Find("Image").GetComponent<Image>();
        if(!string.IsNullOrEmpty(stackItem.item.itemName))
        {

            displayText.text = stackItem.item.itemName;
            displayImage.sprite = stackItem.item.icon;
            displayImage.color = Color.white;
        }
        else
        {
            displayText.text = "";
            displayImage.sprite = null;
            displayImage.color = Color.clear;
        }
    
    }


  
    
}
