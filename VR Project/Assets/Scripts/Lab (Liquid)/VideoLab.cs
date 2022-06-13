using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoLab : MonoBehaviour
{
  [SerializeField]
  private VideoPlayer video;
  [SerializeField]
  private VideoPlayer video2;

  private GameObject Player;

  void Start() {
      Player = GameObject.Find("XR Origin");
  }
  
  IEnumerator One()
  {
      video.Pause();
      yield return new WaitForSeconds(10f);
      video.Play();
      yield return null;
  }

  IEnumerator Two()
  {
      yield return new WaitForSeconds(2f);
      video2.Play();
      yield return null;
  }

  public void QuizTwo()
  {
      StartCoroutine(Two());
  }

  void Update() {
      Collider[] colls = Physics.OverlapSphere(transform.position, .4f);
      if (colls.Length > 0)
        StartCoroutine(One());
  }
}
