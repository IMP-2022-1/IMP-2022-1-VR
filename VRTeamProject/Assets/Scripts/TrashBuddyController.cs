using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBuddyController : MonoBehaviour
{
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Trash"))
        {
            score = score + 1;
            Debug.Log("Your score : " + score);
            Destroy(collider.gameObject);
            if(score == 7)
            {
                Debug.Log("Level Cleared!");
            }
        }
    }
}
