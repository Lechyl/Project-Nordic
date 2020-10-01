using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "AI/Actions/RandomMove")]
public class RandomMovementAction : Action
{


    public override void Act(EnemyController controller)
    {
        if (controller.agent.enabled)
        {


            if (!controller.inCoRoutine)
            {
               

                    Coroutine.instance.StartCoroutine(DoSomething(controller));

                //StartCoroutine
            }
        }

    }




    IEnumerator DoSomething(EnemyController controller)
    {
        controller.inCoRoutine = true;

            
            yield return new WaitForSeconds(controller.timeForNewPath);
            GetNewPath(controller);
            controller.inCoRoutine = false;

    }



    //        Coroutine.instance.StartCoroutine(Waiter(controller));



    private void GetNewPath(EnemyController controller)
    {
        if (controller.agent != null && controller.agent.enabled)
            controller.agent.SetDestination(GetnewrandomPosition(controller));

    }
    Vector3 GetnewrandomPosition(EnemyController controller)
    {
        float x = Random.Range(controller.GetComponentInParent<Spawn>().spawnRadius * -1, controller.GetComponentInParent<Spawn>().spawnRadius);
        float z = Random.Range(controller.GetComponentInParent<Spawn>().spawnRadius * -1, controller.GetComponentInParent<Spawn>().spawnRadius);

        //Vector3 pos = new Vector3(x , 0, z);
        Vector3 pos = new Vector3(x + controller.GetComponentInParent<Spawn>().transform.position.x, 0, z + controller.GetComponentInParent<Spawn>().transform.position.z);
        // controller.agent.transform.position.z

        return pos;
    }


}
