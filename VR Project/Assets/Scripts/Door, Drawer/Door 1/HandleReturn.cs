using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleReturn : MonoBehaviour
{
    //https://www.youtube.com/watch?v=3cJ_uq1m-dg : How to make a door in VR

    public Transform handler;

    // Start is called before the first frame update
    void Start()
    {
        handler = transform.parent;
    }

    public void ReturnToHandle ()
    {
        transform.position = handler.position;
        transform.rotation = handler.rotation;

        Rigidbody rbhandler = handler.GetComponent<Rigidbody>();
        rbhandler.velocity = Vector3.zero;
        rbhandler.angularVelocity = Vector3.zero;
    }

    private void Update()
    {
        if(Vector3.Distance(handler.position, transform.position) > 0.4f)
        {
            // grab done code (But this match OVR)
        }
    }
}
