using UnityEngine;
using System.Collections;
using Pathfinding;

public class Blackboard
{
    private Stats stats;

    public void SetStats(Stats value)
    {
        stats = value;
    }

    public Stats.TargetTypes TargetType
    {
        get { return stats.TargetType; }
        set { stats.TargetType = value; }
    }

    public int MaxHP
    {
        get { return stats.MaxHP; }
    }

    public int HP
    {
        get { return stats.HP; }
        set { stats.HP = value; }
    }

    public int Damage
    {
        get { return stats.Damage; }
    }

    public float MoveSpeed
    {
        get { return stats.MoveSpeed; }
        set { stats.MoveSpeed = value; }
    }

    public float DefaultSpeed
    {
        get { return stats.DefaultSpeed; }
    }

    public float SpotDistance
    {
        get { return stats.SpotDistance; }
    }

    public float AttackRange
    {
        get { return stats.AttackRange; }
    }

    public float AttackTimer
    {
        get { return stats.AttackTimer; }
        set { stats.AttackTimer = value; }
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

    public float FleeingThreshold
    {
        get { return stats.FleeingThreshold; }
    }

    public bool IsWalking
    {
        get { return stats.IsWalking; }
        set { stats.IsWalking = value; }
    }

    public bool IsIdling
    {
        get { return stats.IsIdling; }
        set { stats.IsIdling = value; }
    }

    public Vector3 TargetPosition
    {
        get { return stats.TargetPosition; }
        set { stats.TargetPosition = value; }
    }

    public Vector3 Position
    {
        get { return stats.Position; }
    }

    public Quaternion Rotation
    {
        get { return stats.Rotation; }
        set { stats.Rotation = value; }
    }

    public Seeker GetSeeker
    {
        get { return stats.GetSeeker; }
    }

    public Path CurrentPath
    {
        get { return stats.CurrentPath; }
        set { stats.CurrentPath = value; }
    }

    public Rigidbody GetRigidBody
    {
        get { return stats.GetRigidbody; }
    }

    public Vector3 GetMapSize
    {
        get { return stats.GetMapSize; }
    }

    public GameObject GetMonolith
    {
        get { return stats.GetMonolith; }
    }
}
