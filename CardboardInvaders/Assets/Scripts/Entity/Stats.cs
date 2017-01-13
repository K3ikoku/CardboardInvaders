using UnityEngine;
using System.Collections;
using Pathfinding;




public class Stats : MonoBehaviour
{
   public enum TargetTypes
    {
        UNDEFINED, 
        RANDOM, 
        PLAYER,
    }

    [SerializeField]
    private TargetTypes targetType = TargetTypes.UNDEFINED;

    [SerializeField]
    private int maxHP;
    [SerializeField]
    private int currentHP;
    [SerializeField]
    private int damage;

    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float defaultSpeed;
    [SerializeField]
    private float spotDist;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackTimer;
    [SerializeField]
    private float idleTimer;
    [SerializeField]
    private float idleCD;
    [SerializeField]
    private float fleeingThreshold;

    [SerializeField]
    private bool isWalking = true;
    [SerializeField]
    private bool isIdling = false;

    private Vector3 targetPos;
    private Seeker seeker;
    private Path path;
    private GameObject player;
    private Rigidbody rigid;
    private GameObject ground;
    private GameObject monolith;

    void Awake()
    {
        currentHP = maxHP;
        seeker = GetComponent<Seeker>();
        if(seeker == null)
        {
            Debug.Log("Seeker is missing from " + gameObject);
        }

        //TODO: Implement way to find the monolith

        rigid = GetComponent<Rigidbody>();
        if(rigid == null)
        {
            Debug.Log("Rigidbody is missing from " + gameObject);
        }

        monolith = GameObject.FindGameObjectWithTag("Monolith");
        if(monolith == null)
        {
            Debug.Log("Monolith could not be found");
        }

        ground = GameObject.FindGameObjectWithTag("Ground");
        if(ground == null)
        {
            Debug.Log("Ground could not be found");
        }
    }

    public TargetTypes TargetType
    {
        get { return targetType; }
        set { targetType = value; }
    }

    public int MaxHP
    {
        get { return maxHP; }
    }

    public int HP
    {
        get { return currentHP; }
        set { currentHP = value; }
    }

    public int Damage
    {
        get { return damage; }
    }

    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public float DefaultSpeed
    {
        get { return defaultSpeed; }
    }

    public float SpotDistance
    {
        get { return spotDist; }
    }

    public float AttackRange
    {
        get { return attackRange; }
    }
    public float AttackTimer
    {
        get { return attackTimer; }
        set { attackTimer = value; }
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

    public float FleeingThreshold
    {
        get { return fleeingThreshold; }
    }

    public bool IsWalking
    {
        get { return isWalking; }
        set { isWalking = value; }
    }

    public bool IsIdling
    {
        get { return isIdling; }
        set { isIdling = value; }
    }

    public Vector3 TargetPosition
    {
        get { return targetPos; }
        set { targetPos = value; }
    }

    public Vector3 Position
    {
        get { return transform.position; }
    }

    public Quaternion Rotation
    {
        get { return transform.rotation; }
        set { transform.rotation = value; }
    }

    public Seeker GetSeeker
    {
        get { return seeker; }
    }

    public Path CurrentPath
    {
        get { return path; }
        set { path = value; }
    }

    //TODO: Implement Attack function

    public Rigidbody GetRigidbody
    {
        get { return rigid;  }
    }

    public Vector3 GetMapSize
    {
        get { return ground.transform.position; }
    }

    public GameObject GetMonolith
    {
        get { return monolith; }
    }
}
