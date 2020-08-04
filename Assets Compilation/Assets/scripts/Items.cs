using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class Items : MonoBehaviour
{
    public string itemName;
    public string discription;

    public bool equiptable; 
    public bool hotbariable;
    public bool consumable;

}
