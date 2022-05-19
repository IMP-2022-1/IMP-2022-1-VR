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

    [SerializeField]
    private STATE bottleState = STATE.NONACTIVE;
    [SerializeField]
    private float boundaryHeight;
    [SerializeField]
    private float speed = 0.1f;
    private LiquidVolume liquidVolume;

    void Awake()
    {
        liquidVolume = GetComponent<LiquidVolume>();
    }

    void Update()
    {
        statusCheck();
    }

    private void statusCheck()
    {
        // check the activate status
        RaycastHit hit;
        // Debug.DrawRay(transform.position, transform.up * 0.5f, Color.red);

        if (Physics.Raycast(transform.position, transform.up, out hit, 0.5f))
        {
            // Debug.Log(hit.collider.gameObject.name);
            bottleState =
                hit.collider.gameObject.name == "Glass"
                ? STATE.ACTIVE
                : STATE.NONACTIVE;
        }

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

    private void bottlePourOn()
    {
        // when we pour the liquid
        if (liquidVolume.level >= 0) liquidVolume.level -= Time.deltaTime * speed;
        else liquidVolume.level = 0;

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
