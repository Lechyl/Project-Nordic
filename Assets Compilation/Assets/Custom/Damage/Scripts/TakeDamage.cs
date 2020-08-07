using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TakeDamage : ScriptableObject
{



    public void CheckDamage(Collider DamageTaken)
    {
        if (DamageTaken.tag == "Test")
        {
            Wepons weapon = DamageTaken.GetComponent<Wepons>();
            Debug.Log("DMG " + weapon.dmg);

        }
    }
}
