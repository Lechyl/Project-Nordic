using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NpcmenuSlotControler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public GameObject Npc;
    public GameObject ButtonPrefab; 

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Left == eventData.button)
        {
            Transform enemyInventory = eventData.pointerPress.transform.parent.parent.Find("EnemyInventory");
            Transform questpanel = eventData.pointerPress.transform.parent.parent.Find("QuestPanel");
            Transform questScrollPanel = eventData.pointerPress.transform.parent.parent.Find("QuestScrollPanel");

            if (eventData.pointerPress.name == "Shop")
            {
                if (!enemyInventory.gameObject.activeSelf)
                {

                    questpanel.gameObject.SetActive(false);
                    questScrollPanel.gameObject.SetActive(false);
                    enemyInventory.gameObject.SetActive(true);
                }
                else
                {
                    enemyInventory.gameObject.SetActive(false);

                }
            }
            else if (eventData.pointerPress.name == "Quest")
            {
               
                if (!questpanel.gameObject.activeSelf)
                {
                    
                    enemyInventory.gameObject.SetActive(false);
                    questScrollPanel.gameObject.SetActive(true);

                    // Loop the list to remove all previous children 
                    foreach (Transform child in questScrollPanel.GetChild(0).GetChild(0).GetChild(0))
                    {
                        Destroy(child.gameObject); 
                    }

                     
                    // Make a button for each quest, and give it quest data. 
                    foreach (Quest quest in Npc.GetComponent<QuestGiver>().quest)
                    {
                        if (!(quest.IsActive == false && quest.Iscomplete == true))
                        {

                            ButtonPrefab.GetComponent<QuestSlot>().quest = quest; 
                            ButtonPrefab.GetComponent<QuestSlot>().Npc = Npc;
                            ButtonPrefab.transform.GetChild(0).GetComponent<Text>().text = quest.name; 
                            Instantiate(ButtonPrefab, questScrollPanel.GetChild(0).GetChild(0).GetChild(0));
                        }
                        
                    }

                }
                else
                {
                    questpanel.gameObject.SetActive(false);

                }
            }

        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
