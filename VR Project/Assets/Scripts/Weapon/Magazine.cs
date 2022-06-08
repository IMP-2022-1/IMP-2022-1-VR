using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public int numOfAmmo = 8;
    [SerializeField] private SocketTag magazineInventory;
    [SerializeField] private SimpleShoot gunPrefab;

    void Start()
    {
        gunPrefab = GameObject.FindGameObjectWithTag("Weapon").GetComponent<SimpleShoot>();
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            if (!magazineInventory.hasSelection && gunPrefab.getWeapon)
            {
                transform.position = magazineInventory.transform.position;
                numOfAmmo = 8;
            }
        }
    }

    public bool isEmpty()
    {
        if(numOfAmmo == 0)
            return true;
        else
            return false;
    }

    
}
