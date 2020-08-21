using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Decisions/Look")]
public class LookDecision : Decision
{
    public override bool Decide(EnemyController controller)
    {
        bool targetVisible = Look(controller);
        return targetVisible;

    }

    private bool Look(EnemyController controller)
    {
        RaycastHit hit;

        //draw Eyes look range
        Debug.DrawRay(controller.eyes.position, controller.eyes.forward.normalized * controller.enemyStats.lookRange, Color.green);

        bool Sphere = Physics.SphereCast(controller.eyes.position, controller.enemyStats.lookSphereCastRadius, controller.eyes.forward, out hit, controller.enemyStats.lookRange);

        if ( Sphere && hit.collider.CompareTag("Player"))
        {
            controller.chaseTarget = hit.transform;
            Debug.Log(controller.chaseTarget.position);

            // controller.agent.isStopped = true;
            return true;
        }
        else
        {
           // Debug.Log("Target not Visible");

            return false;
        }
    }
}
