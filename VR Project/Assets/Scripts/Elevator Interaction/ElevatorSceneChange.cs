using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ElevatorSceneChange : MonoBehaviour
{
    float TimeCheck;

    public Canvas GameOverUI;
    private bool NextSceneOnceChecked;

    // Start is called before the first frame update
    void Start()
    {
        NextSceneOnceChecked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverUI == null)
        {
            GameOverUI = GameObject.Find("GameManager").transform.GetChild(2).GetComponent<Canvas>();
    }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            TimeCheck += Time.deltaTime;

            Debug.Log("Excuetion1");

            if (TimeCheck > 2)
            {
                Debug.Log("Excuetion2");

                if (!NextSceneOnceChecked)
                {
                    Debug.Log("Excuetion3");

                    NextSceneOnceChecked = true;
                    GameOverUI.gameObject.SetActive(true);

                    StartCoroutine("ToNextFloor");
                }
            }
        }
    }

    IEnumerator ToNextFloor()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().cardCheck = true;

        Image BlackImage = GameOverUI.transform.GetChild(0).GetComponent<Image>();
        Color ImageColor = BlackImage.color;

        for (float i = 0; i < 1; i += 0.01f)
        {
            ImageColor.a += 0.01f;
            BlackImage.color = ImageColor;
            yield return new WaitForSeconds(0.01f);
        }

        NextSceneOnceChecked = false;
        ImageColor.a = 0;
        BlackImage.color = ImageColor;
        GameOverUI.gameObject.SetActive(false);

        // Check GameOver Scene name is "GameOver"
        SceneManager.LoadScene("Floor 2");
    }
}
