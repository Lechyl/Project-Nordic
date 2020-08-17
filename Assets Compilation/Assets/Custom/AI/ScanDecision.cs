using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="AI/Decisions/Scan")]
public class ScanDecision : Decision
{
    public override bool Decide(EnemyController controller)
    {
        bool noEnemyInSight = Scan(controller);
        
        Debug.Log("Scan");
        return noEnemyInSight;
    }

    private bool Scan(EnemyController controller)
    {
        controller.agent.isStopped = true;

        controller.transform.Rotate(0, controller.enemyStats.searchingTurnSpeed * Time.deltaTime,0 );

        return controller.CheckIfCountDownElapsed(controller.enemyStats.searchDuration);
    }
}
