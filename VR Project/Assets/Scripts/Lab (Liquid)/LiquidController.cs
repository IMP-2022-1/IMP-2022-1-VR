using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidController : MonoBehaviour
{
    public enum COLOR
    {
        RED, BLUE, GREEN, YELLOW, MAGENTA, WHITE
    }
    public Color liquidColor;

    public Color colorState(COLOR state)
    {
        switch (state)
        {
            case COLOR.RED:
                liquidColor = new Color(255, 0, 0, 0.2f);
                break;
            case COLOR.BLUE:
                liquidColor = new Color(0, 0, 255, 0.2f);
                break;
            case COLOR.GREEN:
                liquidColor = new Color(0, 255, 0, 0.2f);
                break;
            case COLOR.YELLOW:
                liquidColor = new Color(255, 255, 0, 0.2f);
                break;
            case COLOR.MAGENTA:
                liquidColor = new Color(255, 0, 255, 0.2f);
                break;
            case COLOR.WHITE:
                liquidColor = new Color(255, 255, 255, 0.2f);
                break;
            default:
                break;
        }

        return liquidColor;
    }
}
