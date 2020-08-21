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
            Debug.Log(damage);

            health.CurrentHp -= damage;

            if (health.CurrentHp <= 0 )
            {
                health.death(); 
            }
 
    }
    public void CheckAiDamage(Collider DamageTaken, EnemyController enemyController)
    {
        Wepons weapon = DamageTaken.GetComponent<Wepons>();

        float damage = weapon.dmg;
        Debug.Log(damage);

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
