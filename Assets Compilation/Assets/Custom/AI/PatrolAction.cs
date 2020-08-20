using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="AI/Actions/Patrol")]
public class PatrolAction : Action
{
    public override void Act(EnemyController controller)
    {
        Patrol(controller);
    }

    private void Patrol(EnemyController controller)
    {
        //Set next waypoint for navMeshAgent
        controller.agent.destination = controller.wayPointList[controller.nextWayPoint].position;
        //walk toward position
       
        controller.agent.isStopped = false;
        controller.canDespawn = true;

        if (controller.agent.remainingDistance <= controller.agent.stoppingDistance && !controller.agent.pathPending)
        {
            controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Count;
        }
    }
}
