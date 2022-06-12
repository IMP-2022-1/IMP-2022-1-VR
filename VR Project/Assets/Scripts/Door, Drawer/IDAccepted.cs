using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDAccepted : MonoBehaviour
{
    private int Security;
    Ray ray;

    // Start is called before the first frame update
    void Start()
    {
        Security = 1 << LayerMask.NameToLayer("Security");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Security"))
        {
            Debug.Log("Security Entered");

            ray = new Ray(transform.position, -transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, Security))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Security Door Open");
                    hit.collider.GetComponent<SecurityDoorOpen>().DoorOpen();
                }
            }

            // I want to remove this
            if (Vector3.Distance(other.transform.position, transform.position) < 0.2)
            {
                other.transform.GetChild(0).GetComponent<SecurityDoorOpen>().DoorOpen();
            }
        }
    }
}
