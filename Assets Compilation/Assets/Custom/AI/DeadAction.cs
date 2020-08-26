using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Dead")]

public class DeadAction : Action
{
    public State deadState;
    public override void Act(EnemyController controller)
    {
   
        Dead(controller);
    }

    
    private void Dead(EnemyController controller)
    {
       

        if (controller.CurrentHp <= 0)
        {
            controller.currentState = deadState;

            controller.canDespawn = true;
            controller.SetupAI(false);

            controller.eyes.GetChild(0).gameObject.SetActive(false);
            controller.gameObject.GetComponent<BoxCollider>().enabled = false;
            controller.SetRagdollRigidbodyState(false);
            controller.SetRagdollColliderState(true);

            Coroutine.instance.StartCoroutine(Waiter(controller));



        }

    }

    private IEnumerator  Waiter(EnemyController controller)
    {
        yield return new WaitForSecondsRealtime(2);

        controller.SetRagdollRigidbodyState(true);
        controller.SetEnemyAsDeadState();

        DespawnAfterdeath(controller);
    }


    private void DespawnAfterdeath(EnemyController controller)
    {

        Destroy(controller.gameObject, controller.DespawnAfterDeathTime);
    }
}
