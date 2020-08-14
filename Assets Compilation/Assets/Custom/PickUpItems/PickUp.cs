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

            //I might waant to change GetComponent<Wepons>() to conparetag instead because It uses less ressources
            if (pickUpController.targetItem.GetComponent<Wepons>())
            {

           //     if (gameObject != null)
           //     {

                    if(pickUpController.rightHand.childCount > 0)
                    {
                        //Detatch item under Player
                        pickUpController.rightHand.GetChild(0).position = new Vector3(pickUpController.rightHand.position.x,1, pickUpController.rightHand.position.z);
                        pickUpController.rightHand.DetachChildren();

                    }

                //Attach Weapon on Players right hand
                    MeshCollider[] mc = pickUpController.targetItem.gameObject.GetComponents<MeshCollider>();
                    foreach(MeshCollider mcs in mc)
                    {
                        mcs.isTrigger = false;

                }
                     pickUpController.targetItem.gameObject.transform.position = pickUpController.rightHand.transform.position;
                   

                    pickUpController.targetItem.gameObject.transform.SetParent(pickUpController.rightHand.transform);

                pickUpController.targetItem.gameObject.transform.localRotation = Quaternion.identity;

                //   }

            }
            else
            {
                //Item is not an Weapon, Destroy and add to inventory
                pickUpController.inventory.addItem(pickUpController.targetItem);
                Destroy(pickUpController.targetItem.gameObject);
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

        Debug.Log(other.tag);
        if (other.CompareTag("Item"))
        {
            Debug.Log("item");

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
