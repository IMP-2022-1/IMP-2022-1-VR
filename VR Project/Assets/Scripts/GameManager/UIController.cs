using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public CanvasGroup Main;
    public CanvasGroup Option;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackBClicked ()
    {
        Option.gameObject.SetActive(false);
        Main.gameObject.SetActive(true);
    }

    public void OptionBClicked ()
    {
        Option.gameObject.SetActive(true);
        Main.gameObject.SetActive(false);
    }

    public void OpenBClicked ()
    {
        Main.gameObject.SetActive(false);

        // Door Open Method. (Already Implemented - Only Assign and Check)
    }

    public void QuitBClicked ()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
