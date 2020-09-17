using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[System.Serializable]
public abstract class Quest : MonoBehaviour
{

    public bool IsActive; 

    public string Name;
    public string Description;
    public string Reward;
    public int Exp; 
    public int Gold;

}
