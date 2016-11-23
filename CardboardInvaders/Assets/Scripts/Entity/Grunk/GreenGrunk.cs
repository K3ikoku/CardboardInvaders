using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Stats))]
public class GreenGrunk : BaseGrunk
{
    private BehaviorTree m_bt;
    private Blackboard m_bb;
    private Composite m_root;

    protected override void Start()
    {
        base.Start();

        m_bb = new Blackboard();
        m_bb.SetStats(m_stats);
        m_bt = new BehaviorTree();
        m_root = new Selector();

        m_bt.SetRoot(m_root);

        //TODO: Create rest of behavior tree
        
    }
}
