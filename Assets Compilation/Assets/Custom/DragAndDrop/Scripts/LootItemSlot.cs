using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootItemSlot : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //  Texture2D ntext = new Texture2D(1, 1);
            //Sprite newSp = Sprite.Create(ntext, new Rect(0, 0, ntext.width, ntext.height), new Vector2(0.5f, 0.5f));
            Items item = EnemyInventory.instance.inventoryList.GetItemByIdAndDeleteFromInventory(int.Parse(transform.name));


          //  eventData.pointerPress.GetComponentInChildren<Text>().text = "";
           // Sprite sprite = eventData.pointerPress.GetComponentInChildren<Image>().sprite;
            //sprite = null;
            transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "";
            transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = null;

            transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.clear;


            //eventData.pointerPress.GetComponentInChildren<Image>().sprite = sprite;


            Inventory.instance.Add(item);

        }
    }
}
