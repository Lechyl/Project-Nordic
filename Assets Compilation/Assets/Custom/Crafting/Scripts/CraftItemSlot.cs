using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftItemSlot : MonoBehaviour, IDropHandler
{
    private Transform craft1;
    private Transform craft2;
    private Transform craftResult;
    private Button craftButton;
    public InventoryStackItems targetItem;
    public Items healthPotion;
    public Items staminaPotion;
    public Sprite potion;

    private void Start()
    {
        craft1 = this.gameObject.transform.parent.Find("Craft1");
        craft2 = this.gameObject.transform.parent.Find("Craft2");
        craftResult = this.gameObject.transform.parent.Find("CraftResult");
        craftButton = craftResult.transform.GetComponentInChildren<Button>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        targetItem = eventData.pointerDrag.transform.parent.GetComponent<InventorySlotController>().stackItem;
        
        if (eventData.pointerDrag != null)
        {

            //Override this Gameobject StackItem
            //transform.GetChild(0).GetChild(0).GetComponent<Text>().text = eventData.pointerDrag.GetComponentInChildren<Text>().text;
            transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = eventData.pointerDrag.GetComponentInChildren<Image>().sprite;
            transform.GetChild(0).GetChild(1).GetComponent<Image>().color = eventData.pointerDrag.GetComponentInChildren<Image>().color;
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            InventoryStackItems craft1Item = craft1.GetComponent<CraftItemSlot>().targetItem;
            InventoryStackItems craft2Item = craft2.GetComponent<CraftItemSlot>().targetItem;

            bool hasImage = (craft1.GetChild(0).GetChild(1).GetComponent<Image>().sprite != null && craft2.GetChild(0).GetChild(1).GetComponent<Image>().sprite != null);

            if (craft1Item.item == craft2Item.item && hasImage)
            {
                if (craft1Item.stack > 1)
                {
                    if (craft1Item.item.GetType() == typeof(Healing) && craft2Item.item.GetType() == typeof(Healing))
                    {
                        HealthPotion();
                    }
                    else if (craft1Item.item.GetType() == typeof(Stamina) && craft2Item.item.GetType() == typeof(Stamina))
                    {
                        StaminaPotion();
                    }
                    else
                    {
                        Debug.Log("No results");
                        EmptyResult();
                    }
                }
                else
                {
                    Debug.Log("No results");
                    EmptyResult();
                }
            }
            else if (craft1Item != craft2Item && craft1Item.stack != 0 && craft2Item.stack != 0 && hasImage)
            {
                if (craft1Item.item.GetType() == typeof(Healing) && craft2Item.item.GetType() == typeof(Healing))
                {
                    HealthPotion();
                }
                else if (craft1Item.item.GetType() == typeof(Stamina) && craft2Item.item.GetType() == typeof(Stamina))
                {
                    StaminaPotion();
                }
                else
                {
                    Debug.Log("No results");
                    EmptyResult();
                }
            }
        }
    }

    private void EmptyResult()
    {
        craftResult.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "";
        craftResult.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = null;
    }

    public void ClearCrafting()
    {
        craft1.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "";
        craft1.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        craft2.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "";
        craft2.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = null;
        EmptyResult();
    }

    private void HealthPotion()
    {
        craftResult.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "Potion (HP)";
        craftResult.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = potion;

        // Empty crafting window, add potion to inventory
        craftButton.onClick.AddListener(AddHPPotion);
    }

    private void StaminaPotion()
    {
        craftResult.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "Potion (STM)";
        craftResult.GetChild(0).GetChild(1).gameObject.GetComponent<Image>().sprite = potion;

        // Empty crafting window, add potion to inventory
        craftButton.onClick.AddListener(AddSTMPotion);
    }

    void AddHPPotion()
    {
        Debug.Log("HP button clicked");

        if (craftResult.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text == "Potion (HP)")
        {
            RemoveIngredients();
            Inventory.instance.Add(healthPotion);
            ClearCrafting();
        }
    }

    void AddSTMPotion()
    {
        Debug.Log("STM button clicked");
        if (craftResult.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text == "Potion (STM)")
        {
            RemoveIngredients();
            Inventory.instance.Add(staminaPotion);
            ClearCrafting();
        }
    }

    private void RemoveIngredients()
    {
        Inventory.instance.Remove(craft1.GetComponent<CraftItemSlot>().targetItem);
        Inventory.instance.Remove(craft2.GetComponent<CraftItemSlot>().targetItem);
    }
}