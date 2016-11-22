﻿using UnityEngine;
using System.Collections;
using Pathfinding;

public class Stats : MonoBehaviour
{

    public enum TargetType
    {
        UNDEFINED, 
        RANDOM,
        PLAYER
    }
    

    [SerializeField] private TargetType m_currentTargetType = TargetType.UNDEFINED;

    [SerializeField] private float m_maxHP;
    [SerializeField] private float m_currentHealth;
    [SerializeField] private float m_damage;

    [SerializeField] private float m_moveSpeed;
    [SerializeField] private float m_runSpeed;
    [SerializeField] private float m_standardSpeed;
    [SerializeField] private float m_walkSpeed;
    [SerializeField] private float m_maxSpotDistance;
    [SerializeField] private float m_maxAttackDistance;
    [SerializeField] private float m_attackTimer;
    [SerializeField] private float m_idleTimer;
    [SerializeField] private float m_idleCD;
    [SerializeField] private float m_fleeHealthThreshhold;

    [SerializeField] private bool m_canWalk = true;
    [SerializeField] private bool m_isIdling = false;
    [SerializeField] private bool m_canIdle = true;

    [SerializeField] private Vector3 m_target;
    [SerializeField] private Seeker m_seeker;
    [SerializeField] private Path m_path;
    [SerializeField] private CharacterController m_controller;
    [SerializeField] private GameObject m_player;
    [SerializeField] private Rigidbody m_rigidBody;


    void Awake()
    {
        if (gameObject.tag != "Player")
        {
            Health = MaxHp;
            m_seeker = GetComponent<Seeker>();
            if (Seeker == null)
            {
                Debug.Log("Missing seeker");
            }

            m_controller = GetComponent<CharacterController>();
            if (CharController == null)
            {
                Debug.Log("Missing character controller");
            }
            m_player = GameObject.FindGameObjectWithTag("Player");
            if (m_player == null)
            {
                Debug.Log("Missing player");
            }
            m_rigidBody = GetComponent<Rigidbody>();
            if (m_rigidBody == null)
            {
                Debug.Log("Missing Rigidbody");
            }
        }
    }

    public TargetType CurrentTargetType
    {
        get { return m_currentTargetType; }
        set { m_currentTargetType = value; }
    }
    
    public float MaxHp
    {
        get { return m_maxHP; }
        set { m_maxHP = value; }
    }

    public float Health
    {
        get { return m_currentHealth; }
        set { m_currentHealth = value; }
    }

    public float Damage
    {
        get { return m_damage; }
        set { m_damage = value; }
    }

    public float MoveSpeed
    {
        get { return m_moveSpeed; }
        set { m_moveSpeed = value; }
    }

    public float RunSpeed
    {
        get { return m_runSpeed; }
    }

    public float StandardSpeed
    {
        get { return m_standardSpeed; }
    }

    public float WalkSpeed
    {
        get { return m_walkSpeed; }
    }
    
    public float MaxSpotDistance
    {
        get { return m_maxSpotDistance; }
        set { m_maxSpotDistance = value; }
    }

    public float MaxAttackDistance
    {
        get { return m_maxAttackDistance; }
        set { m_maxAttackDistance = value; }
    }

    public float IdleTimer
    {
        get { return m_idleTimer; }
        set { m_idleTimer = value; }
    }

    public float IdleCD
    {
        get { return m_idleCD; }
        set { m_idleCD = value; }
    }
    public float AttackTimer
    {
        get { return m_attackTimer; }
        set { m_attackTimer = value; }
    }

    public float FleeHealthThreshold
    {
        get { return m_fleeHealthThreshhold; }
    }

    public bool CanWalk
    {
        get { return m_canWalk; }
        set { m_canWalk = value; }
    }

    public bool CanIdle
    {
        get { return m_canIdle; }
        set { m_canIdle = value; }
    }

    public bool IsIdling
    {
        get { return m_isIdling; }
        set { m_isIdling = value; }
    }
    public Vector3 Target
    {
        get { return m_target; }
        set { m_target = value; }
    }

    public Vector3 Pos
    {
        get { return transform.position; }
    }

    public Quaternion Rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }

    public Seeker Seeker
    {
        get { return m_seeker; }
    }

    public Path Path
    {
        get { return m_path; }
        set { m_path = value; }
    }
    
    public CharacterController CharController
    {
        get { return m_controller; }
    }

    //public Shoot Shoot
    //{
    //    get { return GetComponent<Shoot>(); }
    //}

    public GameObject Player
    {
        get { return m_player; }
    }

    public Rigidbody Rigidbody
    {
        get { return m_rigidBody; }
    }

}
