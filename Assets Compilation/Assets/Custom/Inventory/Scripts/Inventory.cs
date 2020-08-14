using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject InventoryPanel;

    public static Inventory instance;

    public List<Items> list = new List<Items>();

    void updatePanelSlots()
    {
        int index = 0;
        foreach (Transform child in InventoryPanel.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();
            if (index < list.Count)
            {
                slot.item = list[index];
            }
            else
            {
                slot.item = null;
            }

            slot.updateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
    }
    void Start()
    {
        instance = this;
        updatePanelSlots();
    }

    public void Add(Items item)
    {
        if (list.Count < 20)
        {
            list.Add(item);
        }
        updatePanelSlots();
    }
    public void Remove(Items item)
    {
        list.Remove(item);
        updatePanelSlots();
    }
}