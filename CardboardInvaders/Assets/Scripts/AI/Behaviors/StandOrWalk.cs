using UnityEngine;
using System.Collections;


public class StandOrWalk : Behavior
{
    protected override Status Update(Blackboard bb)
    {
        //Debug.Log("Checking if walk or stand");

        if (bb.TargetType != Stats.TargetTypes.RANDOM)
        {
            if (!bb.IsIdling && !bb.IsWalking)
            {
                Debug.Log("Inside standorwalk");
                int i = Random.Range(0, 100);
                Debug.Log(i);
                //int i = 100;
                if (i >= 50)
                {
                    bb.IsWalking = true;
                    bb.MoveSpeed = bb.DefaultSpeed / 2;

                    return Status.SUCCESS;
                }
                else
                {
                    //bb.IsIdling = true;
                    return Status.FAILURE;
                }
            }

            else
            {
                return Status.FAILURE;
            }
        }

        else
        {
            return Status.SUCCESS;
        }
    }

}
