using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public abstract class Items : MonoBehaviour
{
    public string itemName;
    public string discription;
    public Sprite icon;
    public bool hotbariable;
    public int stackLimit = 1;

}
