using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potionlocate : MonoBehaviour
{
    [SerializeField]
    private Transform RedPos;

    [SerializeField]
    private Transform BluePos;

    void OnCollisionEnter (Collision collision)
    {   
        if (collision.gameObject.CompareTag("RedPotion")) {
            PotionMove(RedPos, collision.gameObject);
            GameObject.Find("PotionCheckArea").GetComponent<PotionController>().ready = true;
        }
        if (collision.gameObject.CompareTag("BluePotion")) {
            PotionMove(BluePos, collision.gameObject);
            GameObject.Find("PotionCheckArea").GetComponent<PotionController>().ready2 = true;
        }
    }

    void PotionMove(Transform pos, GameObject target) {
        target.transform.position = pos.position;
        target.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
