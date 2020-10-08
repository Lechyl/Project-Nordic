using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{


    //public InventoryStackItems ItemTofind;
     
    public int RequiredAmount;
    public int CurrentAmount;


    public void CheckIfDone()
    {
        if (CurrentAmount >= RequiredAmount)
        {
            iscomplete = true;
        }
    }


}
