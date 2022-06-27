using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoorOpen : MonoBehaviour
{

    // Reference : https://www.youtube.com/watch?v=SXoiuOGm12M 

    public Transform endTransform;
    public float speed;

    private Vector3 endPos;
    private bool moving;
    public bool Moving
    {
        get { return moving; }
        set { moving = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        moving = false;
        endPos = endTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
                MoveDoor(endPos);
        }
    }

    public void MoveDoor (Vector3 goalPos)
    {
        float dist = Vector3.Distance(transform.position, goalPos);

        if (dist > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, goalPos, speed * Time.deltaTime);
        } else
        {
            moving = false;
        }
    }


}
