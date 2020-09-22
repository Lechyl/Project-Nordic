using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindQuest : Quest
{
    //public Transform location;

    public InventoryStackItems ItemTofind;
    public int RequiredAmount; 
    public int CurrentAmount;

    public bool isReached()
    {
        return (CurrentAmount >= RequiredAmount); 
    }


}
