using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillQuest : Quest
{

    public Transform location;

    //public InventoryStackItems ItemTofind;
     
    public int RequiredAmount;
    public int CurrentAmount;

    public bool IsReached()
    {
        return (CurrentAmount >= RequiredAmount);
    }

}
