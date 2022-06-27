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

    private bool Animation = false;

    private int blue = 3; // blue is 3 (maximum)
    private int red = 5; // red is 5 (maximum)

    IEnumerator BlueHandle() {
        Animation = true;
        for(int i = 0 ; i < 40 ; i++) {
            Blue.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 40 ; i++) {
            Blue.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        Animation = false;
        yield return null;
    }

    IEnumerator RedHandle() {
        Animation = true;
        for(int i = 0 ; i < 40 ; i++) {
            Red.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 40 ; i++) {
            Red.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        Animation = false;
        yield return null;
    }

    IEnumerator BlueMove() {
        Animation = true;
        for(int i = 0 ; i < 40 ; i++) {
            Blue.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 45 ; i++) {
            Blue.transform.Rotate(1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(0.025f);

        for(int i = 0 ; i < 45 ; i++) {
            Blue.transform.Rotate(-1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }
        
        for(int i = 0 ; i < 40 ; i++) {
            Blue.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        Animation = false;
        yield return null;
    }

    IEnumerator RedMove() {
        Animation = true;
        for(int i = 0 ; i < 40 ; i++) {
            Red.transform.position += new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        for(int i = 0 ; i < 45 ; i++) {
            Red.transform.Rotate(-1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }

        yield return new WaitForSeconds(0.025f);

        for(int i = 0 ; i < 45 ; i++) {
            Red.transform.Rotate(1.0f, 0.0f, 0f, Space.World);
            yield return new WaitForSeconds(0.005f);
        }
        
        for(int i = 0 ; i < 40 ; i++) {
            Red.transform.position -= new Vector3(0, 0.005f, 0);
            yield return new WaitForSeconds(0.005f);
        }

        Animation = false;
        yield return null;
    }

    void Start() {
        ScoreCheck();
    }

    public void bluePour() {
        if (!Animation) {
            StartCoroutine(BlueHandle());
            blue = 3;
            ScoreCheck();
        }
    }

    public void redPour() {
        if (!Animation) {
            StartCoroutine(RedHandle());
            red = 5;
            ScoreCheck();
        }
    }

    public void blueThrow() {
        if (!Animation) {
            StartCoroutine(BlueHandle());
            blue = 0;
            ScoreCheck();
        }
    }

    public void redThrow() {
        if (!Animation) {
            StartCoroutine(RedHandle());
            red = 0;
            ScoreCheck();
        }
    }

    public void toRed() {
        if (!Animation) {
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
    }

    public void toBlue() {
        if(!Animation) {
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
    }

    void ScoreCheck() {
        RedArea.GetComponent<TextMeshProUGUI>().text = red.ToString();
        BlueArea.GetComponent<TextMeshProUGUI>().text = blue.ToString();

        if (red == 4 || blue == 4) {
            GameObject.Find("M1911 Handgun_Model").GetComponent<SimpleShoot>().BulletEnhanced();
            Debug.Log("Reward!");
        }
    }
    
}
