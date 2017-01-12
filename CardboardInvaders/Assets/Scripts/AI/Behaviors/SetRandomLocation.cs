using UnityEngine;
using System.Collections;
using Pathfinding;

public class SetRandomLocation : Behavior
{
    private bool isPathing = false;
    private bool foundPath = false;
    private Status status;
    
    private Path path;

    protected override Status Update(Blackboard bb)
    {
        if (bb.TargetType != Stats.TargetTypes.RANDOM)
        {
            if (!isPathing && !foundPath)
            {
                status = Status.RUNNING;
                //Set the target location to a random place inside the game area
                Debug.Log(bb.GetMapSize);
                bb.TargetPosition = new Vector3((Random.Range(-(bb.GetMapSize.x / 2), (bb.GetMapSize.x / 2))), 0, (Random.Range(-(bb.GetMapSize.y / 2), (bb.GetMapSize.y / 2))));

                bb.GetSeeker.StartPath(bb.Position, bb.TargetPosition, OnPathComplete);

                isPathing = true;
            }

            if (foundPath)
            {
                foundPath = false;
                bb.CurrentPath = path;
                path = null;
                status = Status.SUCCESS;
                bb.TargetType = Stats.TargetTypes.RANDOM;
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
        if(!p.error)
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
