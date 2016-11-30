﻿using UnityEngine;
using System.Collections;
using Pathfinding;

public class SetRandomLocation : Behavior
{
    private bool m_isPathing = false;
    private bool m_foundPath = false;
    private Status m_status;
    
    private Path m_path;


    protected override Status Update(Blackboard bb)
    {
        //Debug.Log("Inside SetRandomLoc");
        //Debug.Log("Setting new random location");

        if (bb.CurrentTargetType != Stats.TargetType.RANDOM_LOCATION)
        {
            if (!m_isPathing && !m_foundPath)
            {
                m_status = Status.RUNNING;


                //Set the target location to a random place inside the game area
                bb.Target = new Vector3((Random.Range(-32, 32)), 0, (Random.Range(-12, 12)));

                bb.Seeker.StartPath(bb.Pos, bb.Target, OnPathComplete);

                m_isPathing = true;
            }

            if (m_foundPath)
            {
                m_foundPath = false;
                bb.Path = m_path;
                m_path = null;
                m_status = Status.SUCCESS;
                bb.CurrentTargetType = Stats.TargetType.RANDOM_LOCATION;


            }

        }

        else
        {
            m_status = Status.SUCCESS;
        }


        return m_status;
    }

    private void OnPathComplete(Path p)
    {
        m_isPathing = false;
        if(!p.error)
        {
            m_foundPath = true;
            m_path = p;
        }
        else
        {
            m_status = Status.FAILURE;
        }
    }
}
