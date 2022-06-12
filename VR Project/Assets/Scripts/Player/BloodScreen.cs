using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodScreen : MonoBehaviour
{


    void Start()
    {
        transform.GetComponent<Canvas>().worldCamera = Camera.main;
    }

    void Update()
    {
        
    }

}
