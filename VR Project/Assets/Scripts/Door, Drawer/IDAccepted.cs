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
            ray = new Ray(transform.position, -transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10, Security))
            {
                if (hit.collider != null)
                {
                    hit.collider.GetComponent<SecurityDoorOpen>().DoorOpen();
                }
            }
        }
    }
}
