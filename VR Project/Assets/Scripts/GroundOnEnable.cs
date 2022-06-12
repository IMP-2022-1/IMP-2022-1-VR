using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GroundOnEnable : MonoBehaviour
{
    GameObject[] Grounds;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<TeleportationArea>().teleportationProvider 
                = GameObject.FindGameObjectWithTag("XROrigin").GetComponent<TeleportationProvider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<TeleportationArea>().teleportationProvider
                = GameObject.FindGameObjectWithTag("XROrigin").GetComponent<TeleportationProvider>();
        }
    }
}
