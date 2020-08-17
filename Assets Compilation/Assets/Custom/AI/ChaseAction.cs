using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{

    public override void Act(EnemyController controller)
    {
        Chase(controller);
    }

    private void Chase( EnemyController controller)
    {
       // Debug.Log(controller.chaseTarget.position);
        controller.agent.isStopped = false;

        controller.agent.destination = controller.chaseTarget.position;
        FaceTarget(controller);
    }

    private void FaceTarget(EnemyController  controller)
    {

        if (controller.agent.velocity.sqrMagnitude > Mathf.Epsilon)
        {
            Debug.Log("rotate");
            
           // Quaternion chaseTargetQuaternion = Quaternion.LookRotation(controller.chaseTarget.position);
            //controller.transform.rotation = Quaternion.RotateTowards(controller.transform.rotation, chaseTargetQuaternion, Time.deltaTime * 2);
              controller.transform.rotation = Quaternion.LookRotation(controller.agent.velocity.normalized);
        }
    }

}
