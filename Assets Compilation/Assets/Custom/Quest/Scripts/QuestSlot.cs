using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour , IPointerClickHandler
{

    public Quest quest;

    public GameObject Npc;


    Transform questpanel;
    Transform QuestScrollPanel; 
  

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Left == eventData.button)
        {
            questpanel = eventData.pointerPress.transform.root.Find("QuestPanel"); 
            QuestScrollPanel = eventData.pointerPress.transform.root.Find("QuestScrollPanel");
           

            QuestScrollPanel.transform.gameObject.SetActive(false);


            questpanel.Find("TextBoxContainer").Find("Name").GetChild(0).GetComponent<Text>().text = quest.questName;
            questpanel.Find("TextBoxContainer").Find("Description").GetChild(0).GetComponent<Text>().text = quest.description;
            questpanel.Find("TextBoxContainer").Find("Reward").GetChild(0).GetComponent<Text>().text = "Reward: " + quest.gold.ToString();

            questpanel.Find("acceptBtn").GetComponent<Button>().onClick.AddListener(addquestToBtn);

            questpanel.Find("backBtn").GetComponent<Button>().onClick.AddListener(backBtnClick);

            questpanel.Find("CompleteBtn").GetComponent<Button>().onClick.AddListener(completeQuestBtn);




            questpanel.transform.gameObject.SetActive(true);

            // set accept button if the quest is not taken and complere button if the quest is completet and ready to turn in. 
            if (quest.isActive == true && quest.iscomplete == true)
            {
                questpanel.Find("CompleteBtn").transform.gameObject.SetActive(true);
                questpanel.Find("acceptBtn").transform.gameObject.SetActive(false);
            }
            else if(quest.isActive == true)
            {
                questpanel.Find("acceptBtn").transform.gameObject.SetActive(false);
                questpanel.Find("CompleteBtn").transform.gameObject.SetActive(false);
            }
            else if (quest.isActive == false && quest.iscomplete == true)
            {
                questpanel.Find("CompleteBtn").transform.gameObject.SetActive(false);
                questpanel.Find("acceptBtn").transform.gameObject.SetActive(false);
            }
            else 
            {
                questpanel.Find("acceptBtn").transform.gameObject.SetActive(true);
                questpanel.Find("CompleteBtn").transform.gameObject.SetActive(false);
            }





        }


    }

    private void addquestToBtn()
    {
        Npc.GetComponent<QuestGiver>().GiveQuest(quest);

        questpanel.Find("acceptBtn").transform.gameObject.SetActive(false); 

    }


    private void completeQuestBtn()
    {
        if (quest.items.Count <= (20 - Inventory.instance.inventoryList.CountItemsInInventory()))
        {


            quest.GiveReward();
            quest.isActive = false;


            if (quest is FindQuest)
            {

                FindQuest findQuest = (FindQuest)quest;

                findQuest.removeItems();

            }


            questpanel.Find("CompleteBtn").transform.gameObject.SetActive(false);
            questpanel.gameObject.SetActive(false);

        }
    }

    public void backBtnClick()
    {
        Debug.Log("back back"); 
        questpanel.gameObject.SetActive(false);
        QuestScrollPanel.gameObject.SetActive(true); 

    }

}
