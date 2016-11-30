using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Stats))]
public class GreenGrunk : BaseGrunk
{
    private BehaviorTree bt;
    private Blackboard bb;
    private Composite root;

    protected override void Start()
    {
        base.Start();

        bb = new Blackboard();
        bb.SetStats(stats);
        bt = new BehaviorTree();
        root = new Selector();

        bt.SetRoot(root);

        //TODO: Create rest of behavior tree
        
    }
}
