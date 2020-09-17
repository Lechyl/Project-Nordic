using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

[System.Serializable]
public class QuestGiver : MonoBehaviour
{
 

    [SerializeField]
    public Quest quest; 

 
    public PlayerController player; 

    public void GiveQuest()
    {
        player.quest.Add(quest); 
    }

}
