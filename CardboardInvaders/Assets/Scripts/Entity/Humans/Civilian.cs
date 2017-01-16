using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Stats))]
public class Civilian : Entity
{
    private BehaviorTree behaviorTree;
    private Blackboard blackboard;
    private Composite root;
    private Composite flee;
    private Composite attack;
    private Composite moveToPlayer;
    private Composite walk;
    private Composite idle;

    // Use this for initialization
    protected override void Start ()
    {
        base.Start();

        blackboard = new Blackboard();
        blackboard.SetStats(stats);
        behaviorTree = new BehaviorTree();
        root = new Selector();

        behaviorTree.SetRoot(root);

        flee = (Composite)root.Add(new Sequence());
        flee.Add(new IsHpLow());
        flee.Add(new SetRandomLocation());
        flee.Add(new MoveToPosition());

        attack = (Composite)root.Add(new Sequence());
        attack.Add(new IsPlayerInRange());
        attack.Add(new Attack());


        moveToPlayer = (Composite)root.Add(new Sequence());
        moveToPlayer.Add(new IsPlayerInSight());
        moveToPlayer.Add(new TargetPlayer());
        moveToPlayer.Add(new MoveToPosition());

        walk = (Composite)root.Add(new Sequence());
        walk.Add(new StandOrWalk());
        walk.Add(new SetRandomLocation());
        walk.Add(new MoveToPosition());

        idle = (Composite)root.Add(new Sequence());
        idle.Add(new Idle());

    }

    // Update is called once per frame
    void Update()
    {
        behaviorTree.Update(blackboard);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    protected override void Destroy()
    {
        base.Destroy();
    }
}
