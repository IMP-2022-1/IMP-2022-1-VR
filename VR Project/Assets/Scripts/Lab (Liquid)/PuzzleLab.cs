using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PuzzleLab : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI RedArea;

    [SerializeField]
    private TextMeshProUGUI BlueArea;

    [SerializeField]
    private GameObject Red;

    [SerializeField]
    private GameObject Blue;

    private int blue = 3; // blue is 3 (maximum)
    private int red = 5; // red is 5 (maximum)

    IEnumerator BlueHandle() {
        for(int i = 0 ; i < 80 ; i++) {
            Blue.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 80 ; i++) {
            Blue.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }

    IEnumerator RedHandle() {
        for(int i = 0 ; i < 80 ; i++) {
            Red.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 80 ; i++) {
            Red.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }

    IEnumerator BlueMove() {
        for(int i = 0 ; i < 80 ; i++) {
            Blue.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 90 ; i++) {
            Blue.transform.Rotate(1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(0.025f);

        for(int i = 0 ; i < 90 ; i++) {
            Blue.transform.Rotate(-1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }
        
        for(int i = 0 ; i < 80 ; i++) {
            Blue.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }

    IEnumerator RedMove() {
        for(int i = 0 ; i < 80 ; i++) {
            Red.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 90 ; i++) {
            Red.transform.Rotate(-1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(0.025f);

        for(int i = 0 ; i < 90 ; i++) {
            Red.transform.Rotate(1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }
        
        for(int i = 0 ; i < 80 ; i++) {
            Red.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        yield return null;
    }

    void Start() {
        ScoreCheck();
    }

    public void bluePour() {
        StartCoroutine(BlueHandle());
        ScoreCheck();
        blue = 3;
    }

    public void redPour() {
        StartCoroutine(RedHandle());
        ScoreCheck();
        red = 5;
    }

    public void blueThrow() {
        StartCoroutine(BlueHandle());
        ScoreCheck();
        blue = 0;
    }

    public void redThrow() {
        StartCoroutine(RedHandle());
        ScoreCheck();
        red = 0;
    }

    public void toRed() {
        StartCoroutine(BlueMove());
        if (blue + red < 5) {
            red = blue + red;
            blue = 0;
        } else {
            blue = (blue + red) - 5;
            red = 5;
        }

        ScoreCheck();
    }

    public void toBlue() {
        StartCoroutine(RedMove());
        if (blue + red < 3) {
            blue = blue + red;
            red = 0;
        } else {
            red = (blue + red) - 3;
            blue = 3;
        }

        ScoreCheck();
    }

    void ScoreCheck() {
        RedArea.GetComponent<TextMeshProUGUI>().text = red.ToString();
        BlueArea.GetComponent<TextMeshProUGUI>().text = blue.ToString();

        if (red == 4 || blue == 4) {
            // 문제 해결 코드 작성
        }
    }
    
}
