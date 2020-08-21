using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]

public class GetHp : ScriptableObject
{

    public void Heal (Collider HpRestore, Health health)
    {
       
        Healing healing = HpRestore.GetComponent<Healing>();

        float hpRestoreAmount = healing.hpRestore;
            
        float sum = health.CurrentHp += hpRestoreAmount;
            
        if(sum > health.MaxHp)
        {
           health.CurrentHp = health.MaxHp; 
        }

      
        
    }

}
