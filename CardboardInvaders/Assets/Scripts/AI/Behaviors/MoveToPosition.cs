using UnityEngine;
using System.Collections;
using Pathfinding;

public class MoveToPosition : Behavior
{
    protected override Status Update(Blackboard bb)
    {
        if (bb.CurrentPath != null)
        {
            //Check if reached the destination and remove the path
            if (0 == bb.CurrentPath.vectorPath.Count)
            {
                bb.CurrentPath = null;
                bb.TargetType = Stats.TargetTypes.UNDEFINED;
                return Status.SUCCESS;
            }

            //Check if the character is close enough to the next waypoint and remove if so
            if (Vector3.Distance(bb.Position, bb.CurrentPath.vectorPath[0]) < 3)
            {
                bb.CurrentPath.vectorPath.RemoveAt(0);
                return Status.SUCCESS;
            }

            //Move the character
            Vector3 m_dir = (bb.CurrentPath.vectorPath[0] - bb.Position).normalized;
            m_dir.y = 0;
            m_dir *= bb.MoveSpeed * Time.deltaTime;
            Rigidbody rb = bb.GetRigidBody;
            rb.MovePosition(bb.Position + m_dir);
            bb.Rotation = Quaternion.LookRotation(m_dir);
            return Status.RUNNING;

        }


        else
        {
            return Status.FAILURE;
        }
    }
}

