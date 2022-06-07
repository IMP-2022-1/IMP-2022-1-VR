using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySocketOffset : MonoBehaviour
{
    private Transform target;

    [SerializeField] Vector3 offset;

    private void Start()
    {
        target = GameObject.Find("Main Camera").transform;
    }

    private void FixedUpdate()
    {
        transform.position = target.position + Vector3.up * offset.y + Vector3.ProjectOnPlane(target.right, Vector3.up) * offset.x + Vector3.ProjectOnPlane(target.forward, Vector3.up) * offset.z;
    }
}
