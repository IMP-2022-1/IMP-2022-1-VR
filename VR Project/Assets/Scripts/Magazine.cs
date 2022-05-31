using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int numOfAmmo = 8;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public bool isEmpty()
    {
        if(numOfAmmo == 0)
            return true;
        else
            return false;
    }

    
}
