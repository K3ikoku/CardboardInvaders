using UnityEngine;
using System.Collections;
using Pathfinding;

public class Blackboard
{
    private Stats stats;

    public void SetStats(Stats stats)
    {
        this.stats = stats;
    }

    public Stats.TargetType CurrentTargetType
    {
        get { return stats.CurrentTargetType; }
        set { stats.CurrentTargetType = value; }
    }
    
    public float MaxHP
    {
        get { return stats.MaxHp; }
    }

    public float Health
        {
        get { return stats.Health; }
        set { stats.Health = value; }
    }

    public float Damage
    {
        get { return stats.Damage; }
        set { stats.Damage = value; }
    }

    public float AttackSpeed
    {
        get { return stats.AttackSpeed; }
    }
    
    public float MoveSpeed
    {
        get { return stats.MoveSpeed; }
        set { stats.MoveSpeed = value; }
    }

    public float RunSpeed
    {
        get { return stats.RunSpeed; }
    }

    public float StandardSpeed
    {
        get { return stats.StandardSpeed; }
    }

    public float WalkSpeed
    {
        get { return stats.WalkSpeed; }
    }

    public float MaxSpotDistance
    {
        get { return stats.MaxSpotDistance; }
    }

    public float MaxAttackDistance
    {
        get { return stats.MaxAttackDistance; }
    }


    public float IdleTimer
    {
        get { return stats.IdleTimer; }
        set { stats.IdleTimer = value; }
    }

    public float IdleCD
    {
        get { return stats.IdleCD; }
        set { stats.IdleCD = value; }
    }

    public float FleeHealthThreshold
    {
        get { return stats.FleeHealthThreshold; }
    }

    public bool CanWalk
    {
        get { return stats.CanWalk; }
        set { stats.CanWalk = value; }
    }

    public bool CanIdle
    {
        get { return stats.CanIdle; }
        set { stats.CanIdle = value; }
    }

    public bool IsIdling
    {
        get { return stats.IsIdling; }
        set { stats.IsIdling = value; }
    }

    public Vector3 Target
    {
        get { return stats.Target; }
        set { stats.Target = value; }
    }

    public Vector3 Pos
    {
        get { return stats.Pos; }
    }

    public Quaternion Rotation
    {
        get { return stats.Rotation; }
        set { stats.Rotation = value; }
    }

    public Seeker Seeker
    {
        get { return stats.Seeker; }
    }
    
    public Path Path
    {
        get { return stats.Path; }
        set { stats.Path = value; }
    }

    public CharacterController CharController
    {
        get { return stats.CharController; }
    }

    public GameObject Player
    {
        get { return stats.Player; }
    }

    public Rigidbody Rigidbody
    {
        get { return stats.Rigidbody; }
    }

}
