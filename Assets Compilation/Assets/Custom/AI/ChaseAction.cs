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




        controller.agent.isStopped = false;
        controller.agent.destination = controller.chaseTarget.position;
        controller.canDespawn = false;
        FaceTarget(controller);

        //Call close Allies
        CallAllies(controller);
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

    private void CallAllies(EnemyController controller)
    {
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
                    if(obj.gameObject.GetComponent<EnemyController>().currentState != controller.currentState)
                    {
                        obj.gameObject.GetComponent<EnemyController>().currentState = controller.currentState;

                        obj.gameObject.GetComponent<EnemyController>().chaseTarget = controller.chaseTarget;

                        obj.gameObject.GetComponent<EnemyController>().remainState = controller.currentState;

                    }


                }
            }
            Debug.Log("call firneds");

        }


    }

}
