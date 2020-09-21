using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{
 

    [SerializeField]
    public List<Quest> quest; 

 
    public PlayerController player; 

    public void GiveQuest(Quest questToGive)
    {
        player.quest.Add(questToGive); 
    }

}
