using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Attack")]
public class AttackAction : Action
{
    public override void Act(EnemyController controller)
    {
        Attack(controller);
    }

    private void Attack(EnemyController controller)
    {
        RaycastHit hit;


        //draw Eyes look range
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.attackRange, Color.red);

        if (Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.attackRange) && hit.collider.CompareTag("Player"))
        {
            Debug.Log("I see thy enemy");
            if (controller.CheckIfCountDownElapsed(controller.enemyStats.attackSpeed))
            {
                // Here you Attack
                Debug.Log("Attacking");
              
            }
            
        }
        else
        {
            //If still in Chase state but can't see Player, rotate toward player position.

            Vector3 rotateTo = new Vector3(controller.chaseTarget.position.x, controller.transform.position.y, controller.chaseTarget.position.z);
            controller.transform.LookAt(rotateTo);
        }
    }
}
