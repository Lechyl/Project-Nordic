using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject inventoryUI;
    public Button interactUI;
    
    //check if object is interactable
    private bool interactable = false;
    private GameObject currentInteractableObject;
    private bool inventoryState = false;
    [SerializeField]
    private List<Items> droppedItems;



    public void InventoryModeOn()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void InventoryModeOff()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Interact(List<Items> items)
    {
        //here we have to put the items from chest/npc to an Inventory where we can take items from to our inventory #Not Implenmented
        droppedItems = items;
        interactUI.gameObject.SetActive(false);

        inventoryUI.SetActive(true);
        // interactable = false;
        inventoryState = true;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && interactable && !inventoryState)
        {
            //Convert object class to Drops because it's there where you can see the droppeditems generated from the chest/Enemy
            Drops drop = currentInteractableObject.GetComponent<Drops>();
            Interact(drop.droppedItems);
            InventoryModeOn();

}
        else if(Input.GetKeyDown(KeyCode.G) && inventoryState)
        {
            InventoryModeOff();
            inventoryUI.SetActive(false);
            inventoryState = false;
            
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
            inventoryState = false;
            inventoryUI.SetActive(false);
            interactUI.gameObject.SetActive(false);
        }

    }


}
