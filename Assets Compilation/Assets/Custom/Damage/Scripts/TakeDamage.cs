using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TakeDamage : ScriptableObject
{



    public float CheckDamage(Collider DamageTaken)
    {
      
            Wepons weapon = DamageTaken.GetComponent<Wepons>();
            Debug.Log("DMG " + weapon.dmg);

            float test = weapon.dmg; 

            return test; 

    }
}
