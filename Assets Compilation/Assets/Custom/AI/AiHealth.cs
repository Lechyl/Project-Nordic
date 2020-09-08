using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class AiHealth : ScriptableObject
{
    public void HpLostByWeapon(Collider other, EnemyController Ai)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            Ai.takeDamage.CheckAiDamage(other, Ai);

         
        }
    }
}
