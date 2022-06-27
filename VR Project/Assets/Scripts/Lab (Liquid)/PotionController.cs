using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : MonoBehaviour
{
    [SerializeField]
    private Transform PotionArea;

    [SerializeField]
    private Transform PotionCeiling;

    [SerializeField]
    private Transform Display;

    public bool ready = false;
    public bool ready2 = false;
    public bool start = false;

    void Update() {
        if (ready && ready2 && !start) {
            StartCoroutine("PotionEnded");
            GameObject.Find("checkedDisplayOn").GetComponent<VideoLab>().QuizTwo();
            start = true;
        }
    }

    IEnumerator PotionEnded() {
        for (int i = 0; i < 130 ; i++) {
            PotionCeiling.position += new Vector3(0.01f, 0, 0);
            PotionArea.position -= new Vector3(0, 0.006f, 0);
            Display.position -= new Vector3(0, 0.025f, 0);
            yield return new WaitForSeconds(0.005f);
        }
        
        yield return null;
    }
}
