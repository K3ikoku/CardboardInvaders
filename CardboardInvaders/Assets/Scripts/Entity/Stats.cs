using UnityEngine;
using System.Collections;
using Pathfinding;




public class Stats : MonoBehaviour
{
    public enum TargetType
    {
        UNDEFINED,
        RANDOM_LOCATION,
        PLAYER,
        HUMAN
    }



    [Header("Health")]
    [SerializeField] private float maxHP;
    [SerializeField] private float currentHealth;
    [Tooltip("The amount of hp loss until they flee")][SerializeField][Range(0, 100)] private float fleeHealthThreshhold;

    [Header("Attack")]
    [SerializeField] private float damage;
    [SerializeField] private float attackSpeed;

    [Header("Movement")]
    [Tooltip("The current movespeed. Change run, base or walk speed")][SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float baseSpeed;
    [SerializeField] private float walkSpeed;
    [Header("Targeting")]
    [SerializeField] private TargetType m_currentTargetType = TargetType.UNDEFINED;
    [SerializeField] private Vector3 target;
    [SerializeField] private float maxSpotDistance;
    [SerializeField] private float maxAttackDistance;

    [Header("Parameters for the behavior tree")]
    [SerializeField] private bool canWalk = true;
    [SerializeField] private bool isIdling = false;
    [SerializeField] private bool canIdle = true;
    [SerializeField] private float idleTimer;
    [SerializeField] private float idleCD;

    private Seeker seeker;
    private Path path;
    private CharacterController characterController;
    private GameObject player;
    private Rigidbody rigidBody;


    void Awake()
    {
        if (gameObject.tag != "Player")
        {
            Health = MaxHp;
            seeker = GetComponent<Seeker>();
            if (Seeker == null)
            {
                Debug.Log("Missing seeker");
            }

            characterController = GetComponent<CharacterController>();
            if (CharController == null)
            {
                Debug.Log("Missing character controller");
            }
            player = GameObject.FindGameObjectWithTag("Player");
            if (player == null)
            {
                Debug.Log("Missing player");
            }
            rigidBody = GetComponent<Rigidbody>();
            if (rigidBody == null)
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
        get { return maxHP; }
    }

    public float Health
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float AttackSpeed
    {
        get { return attackSpeed; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float RunSpeed
    {
        get { return runSpeed; }
    }

    public float StandardSpeed
    {
        get { return baseSpeed; }
    }

    public float WalkSpeed
    {
        get { return walkSpeed; }
    }
    
    public float MaxSpotDistance
    {
        get { return maxSpotDistance; }
    }

    public float MaxAttackDistance
    {
        get { return maxAttackDistance; }
    }

    public float IdleTimer
    {
        get { return idleTimer; }
        set { idleTimer = value; }
    }

    public float IdleCD
    {
        get { return idleCD; }
        set { idleCD = value; }
    }


    public float FleeHealthThreshold
    {
        get { return fleeHealthThreshhold; }
    }

    public bool CanWalk
    {
        get { return canWalk; }
        set { canWalk = value; }
    }

    public bool CanIdle
    {
        get { return canIdle; }
        set { canIdle = value; }
    }

    public bool IsIdling
    {
        get { return isIdling; }
        set { isIdling = value; }
    }
    public Vector3 Target
    {
        get { return target; }
        set { target = value; }
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
        get { return seeker; }
    }

    public Path Path
    {
        get { return path; }
        set { path = value; }
    }
    
    public CharacterController CharController
    {
        get { return characterController; }
    }

    public GameObject Player
    {
        get { return player; }
    }

    public Rigidbody Rigidbody
    {
        get { return rigidBody; }
    }

}
