using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OnTargetReached : MonoBehaviour
{
    private float threshold = 0.02f;
    [SerializeField] private Transform target;
    [SerializeField] private UnityEvent onReached;
    private bool wasReached = false;

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if(distance < threshold && !wasReached)
        {
            onReached.Invoke();
            wasReached = true;
        }
        else if(distance >= threshold)
        {
            wasReached = false;
        }
    }
}
