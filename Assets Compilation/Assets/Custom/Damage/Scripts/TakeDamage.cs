using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TakeDamage : ScriptableObject
{

    public void CheckDamage(Collider DamageTaken, Health health )
    {
        
            Wepons weapon = DamageTaken.GetComponent<Wepons>();

            float damage = weapon.dmg;

            health.CurrentHp -= damage;

        
 
    }
}
