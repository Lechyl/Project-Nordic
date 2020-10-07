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

            //I might waant to change GetComponent<Wepons>() to conparetag instead because It uses less ressources
            if (targetItem is Wepons)
            {


                //set trigger of weapon to true and false


                if (pickUpController.rightHand.childCount > 0)
                    {
                        //Detatch item in Players right hand and reset items values to gamemode
                        pickUpController.rightHand.GetChild(0).position = new Vector3(pickUpController.rightHand.position.x,1, pickUpController.rightHand.position.z);
                        pickUpController.rightHand.GetChild(0).tag = "Item";


                        pickUpController.rightHand.DetachChildren();

                    }



                    //Attach Weapon on Players right hand

                    pickUpController.targetItem.gameObject.tag = "PlayerWeapon";
                    // Set Position for Item  to be equal to Righthand
                    pickUpController.targetItem.gameObject.transform.position = pickUpController.rightHand.transform.position;
                    // equip Weapon to Player righthand
                    pickUpController.targetItem.gameObject.transform.SetParent(pickUpController.rightHand.transform);
                    //Rotate Weapon
                    pickUpController.targetItem.gameObject.transform.localEulerAngles = new Vector3(90, 0, 0);
                    pickUpController.targetItem.gameObject.transform.localPosition = new Vector3(0, 0, 1);



            }
            else
            {
               
                //Item is not an Weapon, Destroy and add to inventory
                if(Inventory.instance.Add(targetItem))
                    pickUpController.targetItem.gameObject.SetActive(false);
                //Destroy(pickUpController.targetItem.gameObject);


                if(targetItem.GetComponent<PartOfQuest>() != null)
                {

                    InventoryStackItems inventoryStackItems = new InventoryStackItems()
                    {
                        //equiptment 
                        item = targetItem,
                        stack = 1
                    };

                    Inventory.instance.CheckInventoryForQuestItems(inventoryStackItems); 

                }

            }


            DeactivatePickUpUI(pickUpController);

        }
        else
        {

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


