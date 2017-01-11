using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Text;

class IsHpLow : Behavior
{
    
    protected override Status Update(Blackboard bb)
    {
        if (bb.HP <= (bb.MaxHP * bb.FleeingThreshold))
        {
            //Setting move speed to running speed
            bb.MoveSpeed = bb.DefaultSpeed * 1.5f;
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
