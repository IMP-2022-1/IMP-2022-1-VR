using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField]
    private Transform RedPos;

    [SerializeField]
    private Transform BluePos;


    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("RedPotion"))
            PotionMove(RedPos, collision.gameObject);
        if (collision.gameObject.CompareTag("BluePotion"))
            PotionMove(BluePos, collision.gameObject);
    }

    void PotionMove(Transform pos, GameObject target) {
        target.transform.position = pos.position;
        target.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
