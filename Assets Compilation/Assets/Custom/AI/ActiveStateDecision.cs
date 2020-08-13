using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName ="AI/Decisions/ActiveState")]
public class ActiveStateDecision : Decision
{
    public override bool Decide(EnemyController controller)
    {
        bool chaseTargetIsActive = controller.chaseTarget.gameObject.activeSelf;
        return chaseTargetIsActive;
    }
}
