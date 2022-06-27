using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCreation : MonoBehaviour
{
    FixedJoint MyFJ;

    // Start is called before the first frame update
    void Start()
    {
        MyFJ = GetComponent<FixedJoint>();
        if (transform.parent == null)
        {
            Debug.Log("this handle must have parent");
            return;
        }

        if (transform.parent.GetComponent<Rigidbody>() == null)
        {
            Debug.Log("this handle's parent must have Rigidbody");
            Debug.Log("and please check parent have Joint");
            return;
        }

        MyFJ.connectedBody = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
