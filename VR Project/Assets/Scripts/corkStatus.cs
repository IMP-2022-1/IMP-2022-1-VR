using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corkStatus : MonoBehaviour
{
    // variable STATE
    public enum STATE
    {
        ACTIVE, NONACTIVE
    };

    [SerializeField]
    private STATE corkState = STATE.NONACTIVE;

    void Update()
    {
        // if (코르크 마개를 잡았을 때 조건 확인)
        // corkState = STATE.ACTIVE;

        corkOn();
    }

    private void corkOn()
    {
        GetComponent<Rigidbody>().isKinematic =
            corkState == STATE.ACTIVE
            ? false
            : true;
    }

}
