using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class TakeDamage : ScriptableObject
{

    public void CheckDamage(Collider DamageTaken, Health health )
    {
            Weapons weapon = DamageTaken.GetComponent<Weapons>();

            float damage = weapon.dmg;

            health.CurrentHp -= damage;

            if (health.CurrentHp <= 0 )
            {
                health.death(); 
            }
 
    }
    public void CheckAiDamage(Collider DamageTaken, EnemyController enemyController)
    {
        Weapons weapon = DamageTaken.GetComponent<Weapons>();

        float damage = weapon.dmg;

        enemyController.CurrentHp -= damage;

        if (enemyController.CurrentHp <= 0)
        {
            AiDeath(); 
        }

    }

    public void AiDeath()
    {
        
    } 

}
