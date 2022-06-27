using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityDoorOpen : MonoBehaviour
{
    public GameObject[] Doors;

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
        for (int i = 0; i < Doors.Length; i++)
        {
            if (Doors[i] == null)
            {
                Debug.Log("Please assign Door");
                return;
            } else
            {
                AutomaticDoorOpen automaticDoorOpen = Doors[i].GetComponent<AutomaticDoorOpen>();
                if (automaticDoorOpen == null)
                    Debug.Log("This Object Doesn't have AutomaticDoorOpen");
                else
                    automaticDoorOpen.Moving = true;
            }
        }
    }
}
