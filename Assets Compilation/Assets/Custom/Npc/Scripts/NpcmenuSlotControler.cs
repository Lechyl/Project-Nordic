using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NpcmenuSlotControler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public GameObject Npc;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Left == eventData.button)
        {
            Transform enemyInventory = eventData.pointerPress.transform.parent.parent.Find("EnemyInventory");
            Transform questpanel = eventData.pointerPress.transform.parent.parent.Find("QuestPanel");
            //Transform player = eventData.pointerPress.transform.parent.parent.parent.Find("Player"); 
            //Transform player = eventData.pointerPress.transform.root.parent;
            if (eventData.pointerPress.name == "Shop")
            {
                if (!enemyInventory.gameObject.activeSelf)
                {

                    questpanel.gameObject.SetActive(false);
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
                    //string tester = this.gameObject.GetComponent<NpcQuestController>().test.name;
                    //Debug.Log("this is the new test " + Npc.GetComponent<QuestGiver>().quest.Name);


                    enemyInventory.gameObject.SetActive(false);
                    questpanel.gameObject.SetActive(true);
                    
                    questpanel.Find("TextBoxContainer").Find("Name").GetChild(0).GetComponent<Text>().text = Npc.GetComponent<QuestGiver>().quest[0].Name; 
                    questpanel.Find("TextBoxContainer").Find("Description").GetChild(0).GetComponent<Text>().text = Npc.GetComponent<QuestGiver>().quest[0].Description;
                    questpanel.Find("TextBoxContainer").Find("Reward").GetChild(0).GetComponent<Text>().text = "Reward: " + Npc.GetComponent<QuestGiver>().quest[0].Gold.ToString();

                    //questpanel.Find("acceptBtn").GetComponent<Button>().onClick.AddListener(Npc.GetComponent<QuestGiver>().GiveQuest); 


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
