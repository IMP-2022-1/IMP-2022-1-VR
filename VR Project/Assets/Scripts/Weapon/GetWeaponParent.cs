using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetWeaponParent : MonoBehaviour
{
    GameObject[] magazines;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void GetParent()
    {
        Debug.Log("Get parent work");
        transform.SetParent(GameObject.Find("GameManager").transform);
        magazines = GameObject.FindGameObjectsWithTag("Magazine");
        for(int i =0; i<magazines.Length; i++)
        {
            magazines[i].GetComponent<GetWeaponParent>().GetMagazineParent();
        }
    }

    public void GetMagazineParent()
    {
        Debug.Log("Get magazine parent work");
        transform.SetParent(GameObject.Find("GameManager").transform);
    }
}
