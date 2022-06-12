using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField]
    private Transform RedPos;

    [SerializeField]
    private Transform BluePos;

    [SerializeField]
    private Transform PotionArea;

    [SerializeField]
    private Transform PotionCeiling;

    public bool ready = false;
    public bool ready2 = false;
    public bool start = false;

    void OnCollisionEnter (Collision collision)
    {   
        if (collision.gameObject.CompareTag("RedPotion")) {
            PotionMove(RedPos, collision.gameObject);
            ready = true;
        }
        if (collision.gameObject.CompareTag("BluePotion")) {
            PotionMove(BluePos, collision.gameObject);
            ready2 = true;
        }
    }

    void PotionMove(Transform pos, GameObject target) {
        target.transform.position = pos.position;
        target.transform.rotation = Quaternion.Euler(0,0,0);
    }

    void Update() {
        if (ready && ready2 && !start) {
            Debug.Log("Wat");
            StartCoroutine("PotionEnded");
            start = true;
        }
    }

    IEnumerator PotionEnded() {
        Debug.Log("Wow");
        for (int i = 0; i < 130 ; i++) {
            PotionCeiling.position += new Vector3(0.01f, 0, 0);
            PotionArea.position -= new Vector3(0, 0.006f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        yield return null;
    }
}
