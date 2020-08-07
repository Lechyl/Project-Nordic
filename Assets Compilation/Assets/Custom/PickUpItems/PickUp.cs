using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class PickUp : ScriptableObject
{

   
        

   public bool PickUpItem(Collider other)
    {
        Items item = other.GetComponent<Items>();
        if (item != null)
        {
            Debug.Log("I am An item " + item.itemName);

          //  Destroy(item);
            return true;

        }
        else
        {
            return false;
        }
    }

}
