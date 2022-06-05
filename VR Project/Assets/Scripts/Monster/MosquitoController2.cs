using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosquitoController2 : MonoBehaviour
{
    // Basic stats
    public enum State { idle, trace, attack, heated, dead }
    public State currentState = State.idle;

    public Transform MainCameraTransform;
    protected NavMeshAgent nvAgent;

    public float OriginalHP = 1;
    public float HP = 1;
    public float Damage = 1;
    public float Speed = 0.3f;

    public float TraceRange = 2;
    public float AttackRange = 0.3f;

    // Used in idle moving
    public Transform IdleEndPos;
    protected Vector3 IdleDestination;
    protected Vector3 IdleEndPosPosition;
    protected bool IsDestinationIdleEnd;

    // Used in Attack
    protected bool checkCollision;
    protected Vector3 OriginalPosition;
    protected float TimeCheck;

    // Used in Heated
    protected float HeatedTimeCheck;
    protected bool HeatedTraceCheck;
    protected float OriginalTraceRange;
    protected float HeatedTraceTime;
    protected float HeatedTraceTimeCheck;

    // x,z cordinate
    protected Vector3 xz;

    // used in animation
    protected Animator animator;
    protected bool isthereSuitableAnimator;
    protected bool Heated;
    protected bool Attacked;
    protected bool Checked;


    void OnEnable()
    {
        whenOnEnable();
    }

    public virtual void whenOnEnable()
    {
        HP = OriginalHP;
        currentState = State.idle;
        nvAgent = GetComponent<NavMeshAgent>();
        MainCameraTransform = GameObject.FindWithTag("MainCamera").transform;

        animator = transform.GetChild(0).GetComponent<Animator>();

        checkCollision = false;
        OriginalPosition = transform.position;
        TimeCheck = 0;
        HeatedTimeCheck = 0;

        // Heated Trace
        HeatedTraceCheck = false;
        OriginalTraceRange = TraceRange;
        HeatedTraceTime = 0;
        HeatedTraceTimeCheck = 3;

        // Animation
        animator = transform.GetChild(0).GetChild(0).GetComponent<Animator>();
        if (animator != null)
        {   if (transform.CompareTag("SmallEnemy"))
                isthereSuitableAnimator = true;
            else
            {
                Debug.Log("this Object don't have suitable animator");
                isthereSuitableAnimator = false;
            }
        }
        else
        {
            Debug.Log("This Object don't have animator");
            isthereSuitableAnimator = false;
        }
        Heated = false;
        Attacked = false;
        Checked = true;
    }

    // Update is called once per frame
    void Update()
    {
        xz = new Vector3(MainCameraTransform.position.x, 0, MainCameraTransform.position.z);
        // transform.LookAt(xz);
        if (HP <= 0)
            currentState = State.dead;

        switch (currentState)
        {
            case State.idle:
                UpdateIdle();
                break;
            case State.trace:
                UpdateTrace();
                break;
            case State.attack:
                UpdateAttack();
                break;
            case State.heated:
                UpdateHeated();
                break;
            case State.dead:
                UpdateDead();
                break;
        }
    }

    public virtual void UpdateIdle()
    {
        if (MainCameraTransform == null)
        {
            Debug.Log("Check MainCameraTransform");
            return;
        }
            

        float distance = (xz - transform.position).magnitude;
        if (distance <= TraceRange)
        {
            currentState = State.trace;
            return;
        }
    }

    public virtual void UpdateTrace()
    {
        // Debug.Log("Monster Moving");

        float distance = (xz - transform.position).magnitude;
        if (distance > TraceRange)
        {
            currentState = State.idle;
            return;
        }

        nvAgent.SetDestination(xz);
        nvAgent.speed = Speed;
        //Debug.Log(xz);
        //Debug.Log(distance);

        if (distance <= AttackRange)
        {
            Debug.Log("UnderAttack");
            nvAgent.ResetPath();
            currentState = State.attack;
            return;
        }

        // Heated Trace
        if (HeatedTraceCheck)
        {
            if (HeatedTraceTime < HeatedTraceTimeCheck)
                HeatedTraceTime += Time.deltaTime;
            else
            {
                TraceRange = OriginalTraceRange;
                HeatedTraceTime = 0;
                HeatedTraceCheck = false;
            }
        }

        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MainCameraTransform.position), 20 * Time.deltaTime);
    }

    public virtual void UpdateAttack()
    {

        if (!checkCollision)
        {

            transform.position = Vector3.MoveTowards(transform.position, xz, Speed * 30 * Time.deltaTime);
            Debug.Log("Under Attack");

            // Animation
            if (isthereSuitableAnimator)
            {
                if (!Checked)
                {
                    animator.SetBool("Attack", false);
                    Checked = true;
                }
                if (!Attacked)
                {
                    animator.SetBool("Attack", true);
                    Attacked = true;
                    Checked = false;
                }
            }
        }
        else
        {

            if (TimeCheck < 2)
            {
                if (Checked && animator.GetBool("Attack"))
                    animator.SetBool("Attack", false);

                TimeCheck += Time.deltaTime;
                nvAgent.ResetPath();
                nvAgent.SetDestination(OriginalPosition);
                nvAgent.speed = 1;
            }
            else
            {
                nvAgent.ResetPath();
                checkCollision = false;
                currentState = State.idle;
                TimeCheck = 0;

                // Animation
                Attacked = false;
                Checked = true;
            }
        }
    }

    public virtual void UpdateHeated()
    {
        // Heated Animation
        if (isthereSuitableAnimator)
        {
            if (!Checked)
            {
                animator.SetBool("Damaged", false);
                Checked = true;
            }
            if (!Heated)
            {
                animator.SetBool("Damaged", true);
                Heated = true;
                Checked = false;
            }
        }

        // if want to make STUN time change, change this number.
        if (HeatedTimeCheck < 0.3)
        {
            HeatedTimeCheck += Time.deltaTime;
        }
        else
        {
            HeatedTraceCheck = true;
            HeatedTraceTime = 0;
            currentState = State.trace;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            checkCollision = true;
            // collision.GetComponent<Component name that have Player's hp>().HP -= Damage
            // if you want to Haptic Vibrate, Insert.
        }

        if (collision.transform.CompareTag("Bullet"))
        {
            TraceRange = 5;
            HP -= 0.4f;
            currentState = State.heated;
        }

        if (collision. transform.CompareTag("HolyBullet"))
        {
            TraceRange = 5;
            HP -= 1f;
            currentState = State.heated;
        }
    }


    public virtual void UpdateDead()
    {
        this.gameObject.SetActive(false);
    }
}
