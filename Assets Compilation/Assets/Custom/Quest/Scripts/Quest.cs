using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class Quest : MonoBehaviour
{

    public bool IsActive;
    public bool Iscomplete;

    public string Name;
    public string Description;
    public string Reward;
    public int Exp; 
    public int Gold;



    public void GiveReward()
    {
        GameObject player =  this.transform.parent.GetComponent<QuestHandeler>().Player;
        Inventory.instance.gold += Gold;  
        player.GetComponent<PlayerController>().playerStats.Exp += Exp;

        Debug.Log("quest is complete"); 

    }
}
