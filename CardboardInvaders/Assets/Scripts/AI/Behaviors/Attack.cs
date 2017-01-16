using UnityEngine;
using System.Collections;

public class Attack : Behavior
{
    protected override Status Update(Blackboard bb)
    {

        Debug.Log("Attacking player");
        //Check if the player is existing
        if (bb.GetMonolith != null)
        {
            //See if the player still has health and attack if it does
            //TODO: Fix this to correspond with players health
            if (bb.GetMonolith != null)
            {
                //Check if ready to attack 
                if (bb.AttackTimer >= 2.5)
                {
                    bb.AttackTimer = 0;

                    bb.Rotation.SetLookRotation(bb.TargetPosition);
                    //bb.Shoot.Fire();
                    Debug.Log("Pew pew attacking");
                    return Status.SUCCESS;
                }

                else
                {
                    bb.AttackTimer += Time.deltaTime;
                    return Status.SUCCESS;
                }
            }
            else
            {
                return Status.FAILURE;
            }
        }

        return Status.FAILURE;
    }
}
