using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LootItemSlot : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Im in");

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(eventData.pointerPress.name);
            //  Texture2D ntext = new Texture2D(1, 1);
            if (transform.GetComponent<InventorySlotController>().stackItem.item.GetType() != typeof(NoItem))
            {

                //Sprite newSp = Sprite.Create(ntext, new Rect(0, 0, ntext.width, ntext.height), new Vector2(0.5f, 0.5f));
                //Items item = EnemyInventory.instance.inventoryList.GetItemByIdAndDeleteFromInventory(int.Parse(transform.name),noitem);


                Items item = EnemyInventory.instance.GetItemFromInventory(int.Parse(transform.name));

                if (Inventory.instance.Add(item))
                {

                    EnemyInventory.instance.DeleteItemFromInventory(int.Parse(transform.name));

                    //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "";
                    //transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = null;
                    //transform.GetChild(0).GetChild(1).GetComponent<Image>().color = Color.clear;

                }

                Debug.Log("righ1t");

                //  eventData.pointerPress.GetComponentInChildren<Text>().text = "";
                // Sprite sprite = eventData.pointerPress.GetComponentInChildren<Image>().sprite;
                //sprite = null;

                Debug.Log("righ3t");

                //eventData.pointerPress.GetComponentInChildren<Image>().sprite = sprite;


            }

        }
    }

}
