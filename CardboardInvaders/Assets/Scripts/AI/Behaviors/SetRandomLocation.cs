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

                //TODO: Find a way to make the positioning genereic based on size of the map
                //Set the target location to a random place inside the game area
                bb.TargetPosition = new Vector3((Random.Range(-32, 32)), 0, (Random.Range(-12, 12)));

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
