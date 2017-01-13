using UnityEngine;
using System.Collections;

public class IsPlayerInSight : Behavior
{
    protected override Status Update(Blackboard bb)
    {
        //Debug.Log("Inside PlayerInSight");
        //Debug.Log("Checking if player is in sight");
        if (bb.GetMonolith == null)
        {
            return Status.FAILURE;
        }
        //Check if the player is within sight range
        if (bb.SpotDistance >= Vector3.Distance(bb.Position, bb.GetMonolith.transform.position))
        {
            bb.MoveSpeed = bb.DefaultSpeed;
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }


}
