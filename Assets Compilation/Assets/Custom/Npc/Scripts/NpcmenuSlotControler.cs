using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NpcmenuSlotControler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (PointerEventData.InputButton.Left == eventData.button)
        {
            Debug.Log(eventData.pointerPress.name);
            Transform enemyInventory = eventData.pointerPress.transform.parent.parent.Find("EnemyInventory");
            Transform questpanel = eventData.pointerPress.transform.parent.parent.Find("QuestPanel");


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
                    enemyInventory.gameObject.SetActive(false);
                    questpanel.gameObject.SetActive(true);
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
