using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public Transform MainCameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 xzPosition = new Vector3(MainCameraTransform.position.x, 0, MainCameraTransform.position.z);
        transform.position = xzPosition;
    }
}
