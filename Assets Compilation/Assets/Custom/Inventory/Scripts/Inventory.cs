using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Inventory : MonoBehaviour
{

    public GameObject InventoryPanel;

    public GameObject equipmentUI;

    public GameObject hotbarUI;

    public static Inventory instance;

    public InventoryList inventoryList;

    public int gold = 0; 

    public int index = 0;

    public EquipmentList equipmentList;

    public HotbarList hotbarList;

    public GameObject tooltip;

    public RectTransform tooltipRect;

    public TextMeshProUGUI tooltipText;
    private Canvas canvas;

    private void Awake()
    {
        canvas = this.GetComponent<Canvas>();
    }

    public void UpdatePanelSlots()
    {
        index = 0;

        foreach (Transform child in InventoryPanel.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < inventoryList.inventoryItems.Count)
            {
                //Debug.Log("slot "+index);
                slot.stackItem = inventoryList.inventoryItems[index];
                //Debug.Log("asd " + slot.item.itemName);

                }
            else
            {
                //  Debug.Log("slet slot " + index);

              //  slot.stackItem = inventoryStackItem;
            }

            slot.UpdateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
      
    }

    //here we instantiate inventory with saved data
    //but for Demo we recreate inventory
    void InstantiateInventory()
    {
        inventoryList.inventoryItems.Clear();


        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItem = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };
        for (int i = 0; i < 20; i++)
        {
            inventoryList.inventoryItems.Add(inventoryStackItem);

        }
        
    }

    void InstantiateHotbar()
    {
        hotbarList.hotbarList.Clear();


        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItem = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };
        for (int i = 0; i < 3; i++)
        {

            hotbarList.hotbarList.Add(inventoryStackItem);

        }
    }
    public void UpdateHotbarSlots()
    {
        index = 0;

        foreach (Transform child in hotbarUI.transform)
        {

            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (index < hotbarList.hotbarList.Count)
            {
                //Debug.Log("slot "+index);
                slot.stackItem = hotbarList.hotbarList[index];
                //Debug.Log("asd " + slot.item.itemName);

            }
            else
            {
                //  Debug.Log("slet slot " + index);

                //  slot.stackItem = inventoryStackItem;
            }

            slot.UpdateInfo();
            //Update slot[index]'s name and icon
            index++;
        }
    }



    void Start()
    {
        instance = this;

        InstantiateInventory();
        UpdatePanelSlots();

        InstantiateHotbar();
        UpdateHotbarSlots();

        InstantiateEquipment();
        UpdateEquiptmentSlot(typeof(NoItem));

    }

    public bool Add(Items item)
    {
        //EditorUtility.SetDirty(item);

        if (inventoryList.inventoryItems.Count == 20 && inventoryList.CountItemsInInventory() < 20 && item.GetType() != typeof(NoItem))
        {
            if(inventoryList.inventoryItems.Exists(x => x.item.itemName == item.itemName && x.item.stackLimit > x.stack))
            {
                inventoryList.inventoryItems.Find(x => x.item.itemName == item.itemName && x.item.stackLimit > x.stack).stack++;

            }
            else
            {
                InventoryStackItems inventoryStackItem = new InventoryStackItems()
                {
                    item = item,
                    stack = 1
                };
                inventoryList.inventoryItems[inventoryList.inventoryItems.FindIndex(x => x.stack == 0)] = inventoryStackItem;

            }
            
            UpdatePanelSlots();
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void Remove(Items item)
    {
        UpdatePanelSlots();
    }

    //################################################################################################### EQUIPMENT ####################################################################################


        public void UpdateEquiptmentSlot(System.Type type)
    {


        foreach (Transform child in equipmentUI.transform.GetChild(0))
        {

            EquipmentSlotController slot = child.GetComponent<EquipmentSlotController>();

            if (slot.name == "HeadSlot" && type == typeof(Head))
            {
                InventoryStackItems newItem = new InventoryStackItems()
                {
                    item = equipmentList.head,
                    stack = 1
                };
                slot.stackItem = newItem;


            }
            else if (slot.name == "BreastplateSlot" && type == typeof(Breastplate))
            {
                InventoryStackItems newItem = new InventoryStackItems()
                {
                    item = equipmentList.breastplate,
                    stack = 1
                };
                slot.stackItem = newItem;

            }
            else if (slot.name == "LegsSlot" && type == typeof(Legs))
            {

                slot.stackItem.item = equipmentList.legs;

            }
            else if (slot.name == "BootsSlot" && type == typeof(Boots))
            {

                slot.stackItem.item = equipmentList.boots;
                slot.stackItem.stack = 1;
            }
            else if (slot.name == "WeaponsSlot" && type == typeof(Wepons))
            {

                slot.stackItem.item = equipmentList.Wepons;
                slot.stackItem.stack = 1;
            }
            else if (slot.name == "SheldSlot" && type == typeof(Wepons))
            {

                slot.stackItem.item = equipmentList.Wepons;
                slot.stackItem.stack = 1;
            }
            else if (type == typeof(NoItem))
            {
                Items item = new NoItem();
                slot.stackItem.item = item;
                slot.stackItem.stack = 0;

            }

            slot.UpdateInfo();
        }
    }

    void InstantiateEquipment()
    {
        NoItem item = new NoItem();
        InventoryStackItems inventoryStackItems = new InventoryStackItems()
        {
            item = item,
            stack = 0
        };


        equipmentList.head = item;
        equipmentList.breastplate = item;
        equipmentList.legs = item;
        equipmentList.boots = item;
        equipmentList.Wepons = item;

    }


    public void ReplaceEquiptment(ReplaceEquiptment to, ReplaceItem from)
    {

        inventoryList.inventoryItems[from.slot] = to.item;

        if (to.item.item.GetType() != typeof(NoItem))
            inventoryList.inventoryItems[from.slot].stack = 4;




        if (to.type == typeof(Head))
        {
            equipmentList.head = from.item.item;




        }
        else if (to.type == typeof(Breastplate))
        {
            equipmentList.breastplate = from.item.item;
        }
        else if (to.type == typeof(Legs))
        {
            equipmentList.legs = from.item.item;

        }
        else if (to.type == typeof(Boots))
        {
            equipmentList.boots = from.item.item;

        }
        else if (to.type == typeof(Wepons))
        {
            equipmentList.Wepons = from.item.item;

        }

        UpdateEquiptmentSlot(from.item.item.GetType());
        UpdatePanelSlots();


    }


    private float padding = 10;


    public void ShowTooltip(Vector3 position)
    {
        tooltip.SetActive(true);

        Canvas.ForceUpdateCanvases();
        //  tooltipText.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = false; // **
        //  tooltipText.transform.parent.GetComponent<HorizontalLayoutGroup>().enabled = true;
        // LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipRect);
        Debug.Log(tooltipRect.rect);
        position.z = 0f;

        float rightEdgeToScreenEdgeDistance = Screen.width - (position.x + tooltipRect.rect.width * canvas.scaleFactor / 2) - padding;
        if (rightEdgeToScreenEdgeDistance < 0)
        {
            position.x += rightEdgeToScreenEdgeDistance;
        }

        float leftEdgeToScreenEdgeDistance = 0 - (position.x - tooltipRect.rect.width * canvas.scaleFactor / 2) + padding;
        if (leftEdgeToScreenEdgeDistance > 0)
        {
            position.x += leftEdgeToScreenEdgeDistance;
        }

        float topEdgeToScreenEdgeDistance = Screen.height - (position.y + tooltipRect.rect.height * canvas.scaleFactor) - padding;
        if (topEdgeToScreenEdgeDistance < 0)
        {
            position.y += topEdgeToScreenEdgeDistance;
        }
        //   tooltipRect.transform.position = position;

        tooltip.transform.position = position;


    }

    public void HideTooltip()
    {
        tooltip.SetActive(false);

    }

    public void ChangeTooltipText(Items item)
    {

        StringBuilder builder = new StringBuilder(item.itemName).AppendLine();

        string slotType = "";
        //Create custom info box according to Item Type
        if (item.GetType().BaseType == typeof(Consumable))
        {
            if (item.GetType() == typeof(Healing))
            {
                Healing healing = (Healing)item;
                builder.Append("Type: " + item.GetType().ToString()).AppendLine();

                builder.Append($"<color=green>Use: Restore ").Append(healing.hpRestore).Append(" Health Points").Append("</color>").AppendLine();
            }
            else if (item.GetType() == typeof(Stamina))
            {
                Stamina stamina = (Stamina)item;
                builder.Append("Type: " + item.GetType().ToString()).AppendLine();

                builder.Append($"<color=green>Use: Restore ").Append(stamina.RestoreStamina).Append(" Stamina Points").Append("</color>").AppendLine();
            }
            else if (item.GetType() == typeof(Stone))
            {
                Stone stone = (Stone)item;
                builder.Append("Type: " + item.GetType().ToString()).AppendLine();

                builder.Append($"<color=green>Use: Restore ").Append(stone.repareamount).Append(" Durability To Your Equipped Weapon").Append("</color>").AppendLine();
            }
            slotType = "[Consumable]";
        }
        else if (item.GetType() == typeof(Wepons))
        {
            Wepons wepon = (Wepons)item;
            builder.Append("Level: ").Append(wepon.lvl).AppendLine();
            builder.Append("Type: " + item.GetType().ToString()).AppendLine();
            builder.Append("Damage: ").Append(wepon.dmg).AppendLine();
            builder.Append("Durability: ").Append(wepon.durability).Append("/").Append(wepon.maxDurability).AppendLine();

        }
        else if (item.GetType().BaseType == typeof(Armor))
        {
            Armor armor = (Armor)item;

            builder.Append("Level: ").Append(armor.lvl).AppendLine();
            builder.Append("Type: " + item.GetType().ToString()).AppendLine();

            builder.Append("+").Append(armor.armorHP).Append(" Max Health points").AppendLine();


            slotType = "[Equipable]";

        }
        else
        {
            slotType = "[Junk]";
        }

        builder.Append("<i>").Append(item.discription).Append("</i>").AppendLine();
        builder.Append("Max Stack: ").Append(item.stackLimit).Append("".PadRight(10, ' ')).AppendLine(slotType);

        tooltipText.text = builder.ToString();



    }



    public void CheckInventoryForQuestItems(InventoryStackItems targetItem)
    {

        int QuestItemsIninventorySum;

        foreach (FindQuest quest in targetItem.item.GetComponent<PartOfQuest>().partOfQuest)
        {
            if (quest.IsActive == true && quest.Iscomplete == false)
            {

                QuestItemsIninventorySum = QuestItemsIninventory(targetItem.item.itemName);
                quest.CurrentAmount = QuestItemsIninventorySum;
                quest.CheckIfDone();

            }

        }

    }


    public int QuestItemsIninventory(string ItemToFind)
    {
        return inventoryList.CountSpecifikItemInInventory(ItemToFind); 
    }

}