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

        if(pickUpController.targetItem != null)
        {
            Debug.Log("Picked up " + pickUpController.targetItem.itemName);

            Destroy(pickUpController.targetItem.gameObject);
            DeactivatePickUpUI(pickUpController);

        }
        else{
            Debug.Log("doesnt exist " + pickUpController.targetItem.itemName);

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
            

            Items item = other.GetComponent<Items>();

            pickUpController.pickUpUIState = true;
            pickUpController.targetItem = item;
            pickUpController.pickUpUI.gameObject.SetActive(true);

            Debug.Log(item.itemName);

            //  Destroy(item);
            

        }
        else
        {
            DeactivatePickUpUI(pickUpController);

        }

        //  UI.gameObject.SetActive(true);

    }
}
