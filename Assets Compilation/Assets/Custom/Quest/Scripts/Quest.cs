using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public class Quest : MonoBehaviour
{

    public bool isActive;
    public bool iscomplete;
    public int id; 
    public string questName;
    public string description;
    public List<Items> items;
    public int exp; 
    public int gold;



    public void GiveReward()
    {
        GameObject player =  this.transform.parent.GetComponent<QuestHandeler>().Player;
        Inventory.instance.gold += gold;  
        player.GetComponent<PlayerController>().playerStats.GainExp(exp);

        Debug.Log("quest is complete"); 


        if(items.Count > 0)
        {
            foreach(Items item in items)
            {
                Inventory.instance.Add(item); 
            }
        }

    }


}
