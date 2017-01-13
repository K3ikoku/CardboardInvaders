using UnityEngine;
using System.Collections;

public class Idle : Behavior
{
    protected override Status Update(Blackboard bb)
    {
        if (bb.IsIdling)
        {
            if (bb.IdleCD <= 0)
            {
                bb.IdleCD = Random.Range(5, 20);
            }

            else
            {
                bb.IdleTimer += Time.deltaTime;
            }


            if (bb.IdleTimer >= bb.IdleCD)
            {
                bb.IsIdling = false;
                bb.IdleTimer = 0;
                bb.TargetType = Stats.TargetTypes.UNDEFINED;
            }
        }
        return Status.SUCCESS;
    }

}
