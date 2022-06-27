using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideSomething : MonoBehaviour
{
    MosquitoController2 mosquitocontroller;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        mosquitocontroller = transform.parent.parent.GetComponent<MosquitoController2>();

        if (mosquitocontroller == null)
        {
            Debug.Log("Wrong place");
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            Debug.Log("Heating!");

            mosquitocontroller.TraceRange = mosquitocontroller.TraceRange * 2;
            mosquitocontroller.HP -= 0.4f;
            mosquitocontroller.currentState = MosquitoController2.State.heated;
        }

        if (collision.transform.CompareTag("HolyBullet"))
        {
            mosquitocontroller.TraceRange = mosquitocontroller.TraceRange * 2;
            mosquitocontroller.HP -= 0.4f;
            mosquitocontroller.currentState = MosquitoController2.State.heated;
        }
    }
}
