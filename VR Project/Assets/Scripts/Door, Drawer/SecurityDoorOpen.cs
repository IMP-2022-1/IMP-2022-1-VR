using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorOpen : MonoBehaviour
{
    public GameObject Door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoorOpen()
    {
        if (Door == null)
        {
            Debug.Log("Please assign Door");
            return;
        }


    }
}
