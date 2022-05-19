using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LiquidVolumeFX;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class LiquidPour : MonoBehaviour
{
    // variable STATE
    public enum STATE
    {
        ACTIVE, NONACTIVE
    };

    public enum AMOUNT
    {
        FULL, MIDDLE, EMPTY
    }

    [SerializeField]
    private STATE bottleState = STATE.NONACTIVE;
    [SerializeField]
    private AMOUNT bottleAmount = AMOUNT.FULL;
    [SerializeField]
    private float boundaryHeight;
    [SerializeField]
    private float speed = 0.2f;
    private LiquidVolume liquidVolume;

    void Awake()
    {
        liquidVolume = GetComponent<LiquidVolume>();
    }

    void Update()
    {
        statusCheck();
        amountCheck();
    }

    private void statusCheck()
    {
        // check the activate status
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.up * 0.5f, Color.red);

        if (Physics.Raycast(transform.position, transform.up, out hit, 0.5f))
        {
            Debug.Log(hit.collider.gameObject.name);
            bottleState =
                hit.collider.gameObject.name == "Glass"
                ? STATE.ACTIVE
                : STATE.NONACTIVE;
        }

        // You can pour if it's active
        if (bottleState == STATE.ACTIVE)
        {
            // condition check
            GameObject hitObject = GameObject.Find(hit.collider.gameObject.name);
            boundaryHeight = hitObject.transform.position.y + 0.2f;
            // Debug.Log(boundaryHeight);
            if (this.transform.position.y >= boundaryHeight)
            {
                bottlePourOn();
            }
        }
    }

    private void amountCheck()
    {
        if (liquidVolume.level > 0.5f) bottleAmount = AMOUNT.FULL;
        else if (liquidVolume.level > 0f) bottleAmount = AMOUNT.MIDDLE;
        else bottleAmount = AMOUNT.EMPTY;
    }

    private void bottlePourOn()
    {
        if (bottleAmount == AMOUNT.FULL)
        {
            if (liquidVolume.level >= 0.5f)
            {
                liquidVolume.level -= Time.deltaTime * speed;
            }
            else liquidVolume.level = 0.5f;
        }
        else if (bottleAmount == AMOUNT.MIDDLE)
        {
            if (liquidVolume.level >= 0f)
            {
                liquidVolume.level -= Time.deltaTime * speed;
            }
            else liquidVolume.level = 0f;
        }

        // Debug.Log(liquidVolume.level);
        liquidVolume.UpdateMaterialProperties();
    }

    private void bottleFillOn()
    {
        // when we fill the bottle
        if (liquidVolume.level <= 1) liquidVolume.level += Time.deltaTime * speed;
        else liquidVolume.level = 1;

        liquidVolume.UpdateMaterialProperties();
    }
}
