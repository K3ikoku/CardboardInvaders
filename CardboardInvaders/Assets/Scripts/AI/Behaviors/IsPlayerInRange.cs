using UnityEngine;
using System.Collections;

public class IsPlayerInRange : Behavior
{
    protected override Status Update(Blackboard bb)
    {
        if (bb.GetMonolith == null)
        {
            return Status.FAILURE;
        }
        if (bb.AttackRange >= Vector3.Distance(bb.Position, bb.GetMonolith.transform.position))
        {
            bb.TargetPosition = bb.GetMonolith.transform.position;
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
