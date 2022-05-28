using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MosquitoController2 : MonoBehaviour
{
    public enum State { idle, trace, attack, dead }
    public State currentState = State.idle;

    protected Transform MainCameraTransform;
    private NavMeshAgent nvAgent;

    public float OriginalHP = 1;
    public float HP = 1;
    public float Damage = 1;
    public float Speed = 1;

    public float TraceRange = 10;
    public float AttackRange = 3;
    // Need for Trace Checking?

    public Animator animator;


    void OnEnable()
    {
        whenOnEnable();
    }

    protected virtual void whenOnEnable()
    {
        currentState = State.idle;
        nvAgent = GetComponent<NavMeshAgent>();
        MainCameraTransform = GameObject.FindWithTag("MainCamera").transform;

        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle:
                UpdateIdle();
                break;
            case State.trace:
                Updatetrace();
                break;
            case State.attack:
                Updateattack();
                break;
            case State.dead:
                Updatedead();
                break;
        }
    }

    protected virtual void UpdateIdle()
    {
        if (MainCameraTransform == null)
        {
            Debug.Log("Check MainCameraTransform");
            return;
        }
            

        float distance = (MainCameraTransform.position - transform.position).magnitude;
        if (distance <= TraceRange)
        {
            currentState = State.trace;
            return;
        }
    }
    protected virtual void Updatetrace()
    {
        Debug.Log("Monster Moving");

        float distance = (MainCameraTransform.position - transform.position).magnitude;
        if (distance > TraceRange)
        {
            currentState = State.trace;
            return;
        }

        nvAgent.SetDestination(MainCameraTransform.position);
        nvAgent.speed = Speed;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MainCameraTransform.position), 20 * Time.deltaTime);
        // LookRotation 그냥 그 방향만 바라보는 거라 바꿔줄 필요 있음.
    }
    protected virtual void Updateattack()
    {
        // MainCamera말고 따로 Player에 관한 값이 들어있는 것을 넣어줄 필요가 있음. Player를 어떻게 구현을 할 것인가.
    }
    protected virtual void Updatedead()
    {

    }
}
