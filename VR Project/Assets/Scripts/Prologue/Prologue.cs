using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Prologue : MonoBehaviour
{
    [SerializeField] private VideoPlayer vid;


    private GameObject gm;

    void Start()
    {
        vid.loopPointReached += CheckOver;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckOver(VideoPlayer vp)
    {
        SceneManager.LoadScene("Floor 1");
    }


}
