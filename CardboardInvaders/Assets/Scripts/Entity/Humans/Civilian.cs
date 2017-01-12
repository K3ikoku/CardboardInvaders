using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Stats))]
public class Civilian : Entity
{
    private BehaviorTree bt;
    private Blackboard bb;
    private Composite root;
    private Composite flee;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        bb = new Blackboard();
        bb.SetStats(stats);
        bt = new BehaviorTree();
        root = new Selector();

        bt.SetRoot(root);
        flee = (Composite)root.Add(new Sequence());
        flee.Add(new IsHpLow());
        flee.Add(new SetRandomLocation());
        

    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
