using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor2Setting : MonoBehaviour
{
    private GameObject[] LabLights;

    // Start is called before the first frame update
    void Start()
    {
        LabLights = GameObject.FindGameObjectsWithTag("Light");

        for (int i = 0; i < LabLights.Length; i++)
        {
            LabLights[i].transform.GetChild(0).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReLight ()
    {
        for (int i = 0; i < LabLights.Length; i++)
        {
            LabLights[i].transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
