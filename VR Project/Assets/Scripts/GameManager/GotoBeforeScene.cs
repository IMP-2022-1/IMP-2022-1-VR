using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoBeforeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResurrectionBClicked()
    {
        Debug.Log("1");
        if (GameManager.instance.BeforeSceneNumber == -1)
            Debug.Log("GameManager is not Ready");
        else
        {
            Debug.Log("2");
            SceneManager.LoadScene(GameManager.instance.BeforeSceneNumber);
        }
    }
}
