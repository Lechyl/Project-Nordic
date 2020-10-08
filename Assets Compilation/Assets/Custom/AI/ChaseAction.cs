using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{

    public override void Act(EnemyController controller)
    {
        Chase(controller);
    }

    private void Chase(EnemyController controller)
    {
        //Call close Allies
        if (!controller.callCloseAllies)
        {
            controller.callCloseAllies = true;


            //Get Layer 9
            int d = 1 << 9;
            //Check for Friends inside a radius by using Layer
            Collider[] collides = Physics.OverlapSphere(controller.transform.position, controller.callAlliesRadius, d, QueryTriggerInteraction.Collide);
            if (collides.Length > 0)
            {
                foreach (var obj in collides)
                {

                    //&& obj.gameObject.GetComponent<EnemyController>().canDespawn == false &&
                    
                    if (obj.gameObject != null && controller.gameObject != null && obj.gameObject.GetComponent<EnemyController>().currentState != controller.currentState)
                    {


                            obj.gameObject.GetComponent<EnemyController>().chaseTarget = controller.chaseTarget;

                            obj.gameObject.GetComponent<EnemyController>().currentState = controller.currentState;

                    }
                    else
                    {
                        Debug.Log("Enemy is null or can despawn");
                    }


                }
            }

        }

        controller.agent.isStopped = false;
        controller.agent.destination = controller.chaseTarget.position;
        controller.canDespawn = false;
        FaceTarget(controller);
    }

    private void FaceTarget(EnemyController controller)
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
