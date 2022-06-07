using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoHeightController : MonoBehaviour
{
    public Transform Destination;
    public MosquitoController2 mosquitoController;

    private void OnEnable()
    {
        if (Destination == null)
            Debug.Log("Please assign destination - if player : MainCamera");

        mosquitoController = transform.parent.GetComponent<MosquitoController2>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 goalPos;

        if (mosquitoController.currentState == MosquitoController2.State.idle)
        {
            if (mosquitoController.IdleEndPos != null)
                Destination = mosquitoController.IdleEndPos;
        } else if (mosquitoController.currentState == MosquitoController2.State.trace || mosquitoController.currentState == MosquitoController2.State.attack)
        {
            Destination = mosquitoController.MainCameraTransform;
        }

        goalPos = new Vector3(transform.position.x, Destination.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, goalPos, Time.deltaTime);
    }
}
