using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

[CreateAssetMenu]
public class PickUp : ScriptableObject
{



    public void PickUpItem(PickUpController pickUpController)
    {
        //Pick up item and add to inventory
        // pickUpController.inventory.addItem(targetItem);
        pickUpController.counter++;

        if (pickUpController.targetItem != null)
        {
            Items targetItem = pickUpController.targetItem.GetComponent<Items>();

           

            //Item is not an Weapon, Destroy and add to inventory
            if (Inventory.instance.Add(targetItem))
            {

                //   pickUpController.targetItem.transform.gameObject.SetActive(false);
                pickUpController.targetItem.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                pickUpController.targetItem.transform.gameObject.GetComponent<Collider>().enabled = false;
                if (pickUpController.targetItem.transform.gameObject.HasComponent<RespawnItem>())
                {
                    pickUpController.targetItem.transform.gameObject.GetComponent<RespawnItem>().Respawn();

                }

            }


            if (targetItem.GetComponent<PartOfQuest>() != null)
            {

                InventoryStackItems inventoryStackItems = new InventoryStackItems()
                {
                    //equiptment 
                    item = targetItem,
                    stack = 1
                };

                Inventory.instance.CheckInventoryForQuestItems(inventoryStackItems);

            }




            DeactivatePickUpUI(pickUpController);

        }


    }

    public void DeactivatePickUpUI(PickUpController pickUpController)
    {
        pickUpController.pickUpUIState = false;
        pickUpController.targetItem = null;
        pickUpController.pickUpUI.gameObject.SetActive(false);


        //    UI.gameObject.par(false);

    }

    public void ActivatePickUpUI(Collider other, PickUpController pickUpController)
    {
        //Activate Pick up UI if trigger an item from the ground

        if (other.CompareTag("Item"))
        {



            pickUpController.pickUpUIState = true;
            pickUpController.targetItem = other.gameObject;
            pickUpController.pickUpUI.gameObject.SetActive(true);

            //Debug.Log(item.itemName);

            //  Destroy(item);


        }
        else
        {
            DeactivatePickUpUI(pickUpController);

        }

        //  UI.gameObject.SetActive(true);

    }

    /*
    public void testCheckInventoryForQuestItems(Items targetItem)
    {

        int QuestItemsIninventorySum;

        foreach (FindQuest quest in targetItem.GetComponent<PartOfQuest>().partOfQuest)
        {
            if (quest.IsActive == true && quest.Iscomplete == false)
            {

                QuestItemsIninventorySum = Inventory.instance.QuestItemsIninventory(targetItem.itemName);
                quest.CurrentAmount = QuestItemsIninventorySum;
                quest.CheckIfDone();

            }


        }

    }
    */
}


