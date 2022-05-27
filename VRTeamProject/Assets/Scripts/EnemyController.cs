using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);

        Vector3 movement = new Vector3(0, 0, Time.deltaTime);
        
        if (gameObject.CompareTag("1"))
        {
            transform.Translate(movement * 0.1f);
        }
        if (gameObject.CompareTag("2"))
        {
            transform.Translate(movement * 0.2f);
        }
        if (gameObject.CompareTag("3"))
        {
            transform.Translate(movement * 0.3f);
        }
    }
}
