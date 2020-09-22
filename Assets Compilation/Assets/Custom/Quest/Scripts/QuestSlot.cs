using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestSlot : MonoBehaviour , IPointerClickHandler
{

    public Quest quest;

    public GameObject Npc; 


    /*   public GameObject questpanel;

       public GameObject QuestScrollPanel; 
    */


    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Left == eventData.button)
        {
            Transform questpanel = eventData.pointerPress.transform.root.Find("QuestPanel"); 
            Transform QuestScrollPanel = eventData.pointerPress.transform.root.Find("QuestScrollPanel");
           

            QuestScrollPanel.transform.gameObject.SetActive(false);


            questpanel.Find("TextBoxContainer").Find("Name").GetChild(0).GetComponent<Text>().text = quest.name;
            questpanel.Find("TextBoxContainer").Find("Description").GetChild(0).GetComponent<Text>().text = quest.Description;
            questpanel.Find("TextBoxContainer").Find("Reward").GetChild(0).GetComponent<Text>().text = "Reward: " + quest.Gold.ToString();


            questpanel.Find("acceptBtn").GetComponent<Button>().onClick.AddListener(addquestToBtn); 


            questpanel.transform.gameObject.SetActive(true); 





        }


    }

    private void addquestToBtn()
    {
        Npc.GetComponent<QuestGiver>().GiveQuest(quest); 
    }
}
