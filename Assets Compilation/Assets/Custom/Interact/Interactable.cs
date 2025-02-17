﻿using Assets.Custom.items.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{

    public GameObject EnemyinventoryUI;
    public GameObject PlayerInventoryUI;
    public GameObject NpcPanel;
    public GameObject Questpanel;
    public GameObject QuestScrollpanel;
    public EnemyInventoryList enemyInventoryList;
    public Button interactUI;
    public GameObject TooltipUI;
    //check if object is interactable
    private bool interactable = false;
    private GameObject currentInteractableObject;
    private bool inventoryState = false;

    // check if npc is interactable
    private bool NpcActive = false;
    private bool NpcState = false;

    [SerializeField]
    //private List<Items> droppedItems;



    public void InventoryModeOn()
    {
        PlayerInventoryUI.SetActive(true);
        EnemyinventoryUI.SetActive(true);
        inventoryState = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void InventoryModeOff()
    {
        List<Items> remainingItems = EnemyInventory.instance.inventoryList.inventory.FindAll(x => x.GetType() != typeof(NoItem));
        currentInteractableObject.GetComponentInParent<Drops>().droppedItems = remainingItems;
        PlayerInventoryUI.SetActive(false);
        EnemyinventoryUI.SetActive(false);
        TooltipUI.SetActive(false);
        inventoryState = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void Interact(List<Items> items)
    {
        //here we have to put the items from chest/npc to an Inventory where we can take items from to our inventory #Not Implenmented
        // droppedItems = items;
        // foreach (var item in droppedItems)
        //   {
        EnemyInventory.instance.ReplaceInventory(items);
        //enemyInventoryList.inventory = droppedItems;

        //   }
        interactUI.gameObject.SetActive(false);

        // interactable = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && interactable && !inventoryState)
        {
            //Convert object class to Drops because it's there where you can see the droppeditems generated from the chest/Enemy
            Drops drop = currentInteractableObject.GetComponentInParent<Drops>();
            Interact(drop.droppedItems);
            InventoryModeOn();

        }
        else if (Input.GetKeyDown(KeyCode.F) && inventoryState)
        {
            InventoryModeOff();


        }
        else if (Input.GetKeyDown(KeyCode.F) && NpcActive && !NpcState)
        {
            Drops drop = currentInteractableObject.GetComponentInParent<Drops>();
            Interact(drop.droppedItems);
            NpcModeOn();
        }
        else if (Input.GetKeyDown(KeyCode.F) && NpcState)
        {
            NpcModeOff();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Interact"))
        {
            currentInteractableObject = other.gameObject;
            interactUI.gameObject.SetActive(true);
            interactable = true;
        }
        // Work in progress 
        if (other.CompareTag("NPC"))
        {
            currentInteractableObject = other.gameObject;
            interactUI.gameObject.SetActive(true);

            NpcPanel.transform.Find("Quest").GetComponent<NpcmenuSlotControler>().Npc = currentInteractableObject;

            //Debug.Log(" this is a test : " + currentInteractableObject.name); 
            NpcActive = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.CompareTag("Interact"))
        {
            interactable = false;
            inventoryState = false;
            EnemyinventoryUI.SetActive(false);
            interactUI.gameObject.SetActive(false);
        }
        // Work in progress 

        if (other.CompareTag("NPC"))
        {
            NpcActive = false;
            //NpcState = false; 
            interactUI.gameObject.SetActive(false);

        }
    }

    public void NpcModeOn()
    {
        NpcPanel.gameObject.SetActive(true);
        NpcState = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;

    }
    public void NpcModeOff()
    {
        NpcPanel.gameObject.SetActive(false);
        Questpanel.gameObject.SetActive(false);
        QuestScrollpanel.gameObject.SetActive(false);
        //PlayerInventoryUI.SetActive(false);
        EnemyinventoryUI.SetActive(false);
        NpcState = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;

    }
}
