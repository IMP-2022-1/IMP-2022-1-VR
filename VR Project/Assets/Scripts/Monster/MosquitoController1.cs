using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoController1 : MonoBehaviour
{
    // Basic Information
    public float OriginalHP = 1;
    public float HP = 1;
    public float Damage = 1;
    public float Speed = 1;
    public int MovingChoice;

    // Used in Moving
    public Transform MainCameraTransform;
    protected Vector3 OriPosition;
    public struct RotatingInformation
    {
        public Vector3 CenterOfRotation;
        public Vector3 RotatingDirection;
    }
    protected RotatingInformation RI;
    protected bool RightLeft;
    protected float betweenDistance;


    // Start is called before the first frame update
    void OnEnable()
    {
        MovingChoice = Random.Range(0, 4);

        MainCameraTransform = GameObject.FindWithTag("MainCamera").transform;
        OriPosition = transform.position;
        if (MovingChoice == 0)
            RI = DecidingCenter();
        else if (MovingChoice == 1)
            RightLeft = true;
        Debug.Log(MovingChoice);
        betweenDistance = Vector3.Distance(transform.position, MainCameraTransform.position);

        // for Object pooling
        HP = OriginalHP;
    }

    // Update is called once per frame
    void Update()
    {
        MosquitoMoving();
    }

    public virtual void MosquitoMoving ()
    {
        MosquitoMovingAround();
        betweenDistance = Vector3.Distance(transform.position, MainCameraTransform.position);
        transform.LookAt(MainCameraTransform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    public virtual void MosquitoMovingAround()
    {
        if (MovingChoice == 0) // Moving 0
        {
            transform.RotateAround(RI.CenterOfRotation, RI.RotatingDirection, Time.deltaTime * transform.localScale.magnitude * 200 / betweenDistance);
        }
        else if (MovingChoice == 1) // Moving 1
        {
            if (RightLeft)
            {
                //Debug.Log("right");
                transform.RotateAround(MainCameraTransform.position, Vector3.up, Time.deltaTime * transform.localScale.magnitude * 30 / betweenDistance);
                if ((OriPosition - transform.position).magnitude > 0.3)
                    RightLeft = false;
            }
            else
            {
                //Debug.Log("Left");
                transform.RotateAround(MainCameraTransform.position, -Vector3.up, Time.deltaTime * transform.localScale.magnitude * 30 / betweenDistance);
                if ((OriPosition - transform.position).magnitude < 0.01)
                    RightLeft = true;
            }
        }
        else if (MovingChoice == 2) // Moving 2
        {
            transform.RotateAround(MainCameraTransform.position, Vector3.up, Time.deltaTime * transform.localScale.magnitude * 30 / betweenDistance);
        }
        else if (MovingChoice == 3) // Moving 3
        {
            float MagnitudeOfScale = transform.localScale.magnitude;
            transform.RotateAround(OriPosition - transform.localScale / 3, Vector3.back, Time.deltaTime * MagnitudeOfScale * 500 / betweenDistance );
        }
    }


    // Used in Moving 0
    public RotatingInformation DecidingCenter()
    {
        float x, y, z;
        float OriPositionMag = OriPosition.magnitude;
        RotatingInformation TempRI = new RotatingInformation();

        x = Random.Range(-OriPosition.x, OriPosition.x);
        y = Random.Range(-OriPosition.y, OriPosition.y);
        z = Mathf.Sqrt(Mathf.Pow(OriPositionMag, 2) - OriPosition.x * x - OriPosition.y * y);
        Vector3 PPlane = new Vector3(x, y, z);
        Vector3 TempCOR = OriPosition - PPlane;
        Vector3 TempCOR2 = TempCOR / TempCOR.magnitude * (transform.localScale.magnitude);
        Vector3 CenterOfRotation = OriPosition + TempCOR2;
        Vector3 RotatingDirection = new Vector3(-TempCOR2.z, 1 / (-TempCOR2.y), TempCOR2.x);

        TempRI.CenterOfRotation = CenterOfRotation;
        TempRI.RotatingDirection = RotatingDirection;

        return TempRI;
    }
}
