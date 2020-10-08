using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        //Death Logic here
        if (controller.CurrentHp <= 0)
        {
            controller.playerStats.GainExp(controller.deathExp);

            isPartOfQuest(controller);

            controller.currentState = deadState;

            controller.canDespawn = true;

            controller.eyes.GetChild(0).gameObject.SetActive(false);
            controller.gameObject.GetComponent<BoxCollider>().enabled = false;
            controller.SetRagdollRigidbodyState(false);
            controller.SetRagdollColliderState(true);


            Coroutine.instance.StartCoroutine(Waiter(controller));


        }

    }

    private IEnumerator  Waiter(EnemyController controller)
    {
        controller.SetupAI(false);

        yield return new WaitForSecondsRealtime(3);


        controller.SetRagdollRigidbodyState(true);
        controller.SetEnemyAsDeadState();

        DespawnAfterdeath(controller);
    }

    private void isPartOfQuest(EnemyController controller) 
    {
        if (controller.partOfQuest.Count >= 1)
        {
                    QuestHandeler.instance.questLog.quests.GetType();

            

            
            foreach (KillQuest quest in controller.partOfQuest)
            {
                Debug.Log("!!!!2!!!");

                var dd = controller.questlog.quests.Find(x => x.id == quest.id).GetComponent<KillQuest>();
                if (dd.isActive == true && dd.iscomplete == false)
                {
                    Debug.Log("!!!!3!!!");
                    controller.questlog.quests.Find(x => x.id == quest.id).GetComponent<KillQuest>().CurrentAmount += 1;
                    controller.questlog.quests.Find(x => x.id == quest.id).GetComponent<KillQuest>().CheckIfDone();

                    //quest.CurrentAmount += 1; 
                    //quest.CheckIfDone();

                }
            }


        }


    }

    private void DespawnAfterdeath(EnemyController controller)
    {

        Destroy(controller.gameObject, controller.DespawnAfterDeathTime);
    }
}
