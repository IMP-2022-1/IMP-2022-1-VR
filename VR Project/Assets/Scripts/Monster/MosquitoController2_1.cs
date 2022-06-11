using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoController2_1 : MosquitoController2
{
    // Bug Fix - Mosquito SetDestination Update
    private bool haveIdleDestination;

    public override void whenOnEnable()
    {
        base.whenOnEnable();

        if (IdleEndPos == null)
        {
            Debug.Log("Please Assign IdleEndPos");
        }
        else
        {
            // If To make maintain more easy, IdleEndPos's GameObject in Mosquito
            // Must Check IdleEndPos's first position
            // And Be careful IdleEndPosPosition's y = 0
            IdleEndPosPosition = new Vector3(IdleEndPos.position.x, 0, IdleEndPos.position.z);
            IdleDestination = IdleEndPosPosition;
            IsDestinationIdleEnd = true;
        }

        haveIdleDestination = false;
    }

    public override void UpdateIdle()
    {
        Debug.Log("IdleMovement");

        if (MainCameraTransform == null)
        {
            Debug.Log("Check MainCameraTransform");
            return;
        }

        if (!haveIdleDestination)
        {
            haveIdleDestination = true;

            StartCoroutine("CoSetD");
        }

        /* Debug.Log(IdleDestination);
        Debug.Log(nvAgent.remainingDistance); */

        if (nvAgent.remainingDistance < 0.1)
        {
            if (IsDestinationIdleEnd)
            {
                IdleDestination = OriginalPosition;
                IsDestinationIdleEnd = false;
            }
            else
            {
                IdleDestination = IdleEndPosPosition;
                IsDestinationIdleEnd = true;
            }

            haveIdleDestination = false;
        }

        float distance = (xz - transform.position).magnitude;
        if (distance <= TraceRange)
        {
            currentState = State.trace;
            return;
        }
    }

    IEnumerator CoSetD()
    {
        nvAgent.SetDestination(IdleDestination);
        nvAgent.speed = Speed;

        yield return null;
    }
}
