using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoLookat : MonoBehaviour
{
    public Transform Destination;

    private void OnEnable()
    {
        Destination = transform.parent.GetComponent<MosquitoHeightController>().Destination;
        if (Destination == null)
            Debug.Log("Please check parent destination - MosquitoHeightController");
    }

    // Update is called once per frame
    void Update()
    {
        Destination = transform.parent.GetComponent<MosquitoHeightController>().Destination;
        transform.LookAt(Destination.position);
    }
}
