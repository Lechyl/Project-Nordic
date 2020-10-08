using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class QuestHandeler : MonoBehaviour
{

    public GameObject Player;

    public QuestLog questLog;

    public static QuestHandeler instance; 

    private void Awake()
    {
        instance = this; 

        questLog.quests.Clear(); 
        foreach (Transform child in transform)
        {
            questLog.quests.Add(child.GetComponent<Quest>()); 

           
        }

       
    }

   




}
