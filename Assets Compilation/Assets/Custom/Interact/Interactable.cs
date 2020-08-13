using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public Button inventoryUI;
    public Button interactUI;

    //check if object is interactable
    private bool interactable = false;
    private GameObject currentInteractableObject;

    [SerializeField]
    private List<Items> droppedItems;

    public void Interact(List<Items> items)
    {
        //here we have to put the items from chest/npc to an Inventory where we can take items from to our inventory #Not Implenmented
        droppedItems = items;
        interactUI.gameObject.SetActive(false);

        inventoryUI.gameObject.SetActive(true);
        interactable = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && interactable)
        {
            //Convert object class to Drops because it's there where you can see the droppeditems generated from the chest/Enemy
            Drops drop = currentInteractableObject.GetComponent<Drops>();
            Interact(drop.droppedItems);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Interact")
        {
            currentInteractableObject = other.gameObject;
            interactUI.gameObject.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if(other.tag == "Interact")
        {
            interactable = false;
            inventoryUI.gameObject.SetActive(false);
            interactUI.gameObject.SetActive(false);
        }

    }


}
