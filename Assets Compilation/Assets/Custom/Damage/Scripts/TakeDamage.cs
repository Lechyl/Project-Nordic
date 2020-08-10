using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TakeDamage : ScriptableObject
{



    public float CheckDamage(Collider DamageTaken)
    {
      
            Wepons weapon = DamageTaken.GetComponent<Wepons>();

            float test = weapon.dmg; 

            return test; 

    }
}
