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

    private int blue = 3; // blue is 3 (maximum)
    private int red = 5; // red is 5 (maximum)

    void Start() {
        ScoreCheck();
    }

    public void bluePour() {
        ScoreCheck();
        blue = 3;
    }

    public void redPour() {
        ScoreCheck();
        red = 5;
    }

    public void blueThrow() {
        ScoreCheck();
        blue = 0;
    }

    public void redThrow() {
        ScoreCheck();
        red = 0;
    }

    public void toRed() {
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
