using UnityEngine;
using System.Collections;
using Pathfinding;

public class TargetPlayer : Behavior
{
    private bool isPathing = false;
    private bool foundPath = false;
    private Status status;
    private Path path;

    protected override Status Update(Blackboard bb)
    {
        if (bb.TargetType != Stats.TargetTypes.PLAYER)
        {
            if (!isPathing && !foundPath)
            {
                status = Status.RUNNING;

                //Set the target location to the players position if not already
                if (bb.TargetPosition != bb.GetMonolith.transform.position)
                {
                    bb.TargetPosition = bb.GetMonolith.transform.position;
                }

                bb.GetSeeker.StartPath(bb.Position, bb.TargetPosition, OnPathComplete);

                isPathing = true;
            }



            if (foundPath)
            {
                foundPath = false;
                bb.CurrentPath = path;
                path = null;
                status = Status.SUCCESS;
                bb.TargetType = Stats.TargetTypes.PLAYER;


            }
        }

        else
        {
            status = Status.SUCCESS;
        }

        return status;
    }


    private void OnPathComplete(Path p)
    {
        isPathing = false;
        if (!p.error)
        {
            foundPath = true;
            path = p;
        }
        else
        {
            status = Status.FAILURE;
        }
    }
}
