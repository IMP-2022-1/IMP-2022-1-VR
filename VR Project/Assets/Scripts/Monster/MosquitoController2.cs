using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosquitoController2 : MonoBehaviour
{
    // Basic stats
    public enum State { idle, trace, attack, dead }
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

    // x,z cordinate
    protected Vector3 xz;

    public Animator animator;


    void OnEnable()
    {
        whenOnEnable();
    }

    public virtual void whenOnEnable()
    {
        currentState = State.idle;
        nvAgent = GetComponent<NavMeshAgent>();
        MainCameraTransform = GameObject.FindWithTag("MainCamera").transform;

        animator = transform.GetChild(0).GetComponent<Animator>();

        checkCollision = false;
        OriginalPosition = transform.position;
        TimeCheck = 0;
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

        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MainCameraTransform.position), 20 * Time.deltaTime);
    }
    public virtual void UpdateAttack()
    {

        if (!checkCollision)
        {
            transform.position = Vector3.MoveTowards(transform.position, xz, Speed * 30 * Time.deltaTime);
            Debug.Log("Under Attack");
        }
        else
        {
            if (TimeCheck < 2)
            {
                TimeCheck += Time.deltaTime;
                nvAgent.SetDestination(OriginalPosition);
                nvAgent.speed = 2;
            }
            else
            {
                checkCollision = false;
                currentState = State.idle;
                TimeCheck = 0;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player")) {
            checkCollision = true;
            // collision.GetComponent<Component name that have Player's hp>().HP -= Damage
        }
    }


    public virtual void UpdateDead()
    {
        this.gameObject.SetActive(false);
    }
}
