using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public int playerHP = 3;

    private bool electricity;
    public bool cardCheck;
    public GameObject hologramPrefab;
    private GameObject hologram;

    public AudioSource audioSource;
    public AudioClip leverClip;
    public AudioClip powerOnClip;
    public AudioClip hologramClip;
    public AudioClip wrongNumberClip;
    public AudioClip rightNumberClip;
    public AudioClip bossLeverClip;

    [SerializeField] private Image bloodScreen;

    private bool bossLever1;
    private bool bossLever2;
    private bool bossLever3;


    // Start is called before the first frame update
    void Start()
    {
        electricity = false;
        cardCheck = true;

        audioSource = GetComponent<AudioSource>();

        bossLever1 = false;
        bossLever2 = false;
        bossLever3 = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Checking player HP
        // PlayerHPChecking(playerHP);
        // PlayerHPChecking In GameManager

        // Checking electricity
        /*if (electricity)
        {
            SlashCard();
        }*/

        SlashCard();
        
        if (playerHP == 3){
            bloodScreen.color = new Color(255, 0, 0, 0);
        }

        if (playerHP == 2){
            bloodScreen.color = new Color(255, 0, 0, 127);
        }

        if (playerHP <= 1){
            bloodScreen.color = new Color(255, 0, 0, 255);

        }
        
        // Checking boss lever to destroy queen mosquito
        if (bossLever1 && bossLever2 && bossLever3)
        {
            Destroy(GameObject.FindGameObjectWithTag("Boss"));
        }

    }


    public void OnPressNumber(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("RightNumber"))
        {
            Debug.Log("Right number pressed");
            audioSource.clip = rightNumberClip;
            audioSource.Play();
            GameObject.Find("DoorOpen").GetComponent<SecurityDoorOpen>().DoorOpen();
        }
        if (args.interactableObject.transform.CompareTag("WrongNumber"))
        {
            Debug.Log("Wrong number pressed");
            audioSource.clip = wrongNumberClip;
            audioSource.Play();
        }
    }

    public void OnGrabCard(SelectEnterEventArgs args)
    {
        GameObject usim = GameObject.FindGameObjectWithTag("Slot");
        GameObject card = GameObject.FindGameObjectWithTag("Card");
        if (args.interactableObject.transform.CompareTag("Card"))
        {
            /*if (Vector3.Distance(usim.transform.position, card.transform.position) < 0.01)
            {
                Debug.Log("Card insert!");
            }*/
            Debug.Log("Grap ID card!");
        }

    }

    public void SlashCard()
    {
        GameObject usim = GameObject.FindGameObjectWithTag("Slot");
        GameObject card = GameObject.FindGameObjectWithTag("Card");
        if (usim != null && card != null)
        {
            if (cardCheck)
            {
                if (Vector3.Distance(usim.transform.position, card.transform.position) < 0.5f)
                {
                    Debug.Log("Hologram appear!");
                    audioSource.clip = hologramClip;
                    audioSource.Play();
                    cardCheck = false;
                    hologram = Instantiate(hologramPrefab, usim.transform.position + new Vector3(0, 0, -0.3f), usim.transform.rotation);
                }
            }
        }

        
    }

    public void OnGrabLever(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("RightLever"))
        {
            Debug.Log("Correct Lever");
            audioSource.clip = leverClip;
            audioSource.Play();
            audioSource.clip = powerOnClip;
            audioSource.Play();
            electricity = true;

            // Light On
            if (GameObject.Find("Floor2Setting") != null)
            {
                GameObject.Find("Floor2Setting").GetComponent<Floor2Setting>().ReLight();
            }
        }
        if (args.interactableObject.transform.CompareTag("WrongLever"))
        {
            Debug.Log("Wrong Lever");
            audioSource.clip = leverClip;
            audioSource.Play();
        }
    }

    public void PlayerHPChecking(int playerHP)
    {
        if(playerHP == 0)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        }
    }

    public void OnGrabBossLever(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("BossLever1"))
        {
            Debug.Log("BossLever1");
            audioSource.clip = bossLeverClip;
            audioSource.Play();
            bossLever1 = true;
        }
        if (args.interactableObject.transform.CompareTag("BossLever2"))
        {
            Debug.Log("BossLever2");
            audioSource.clip = bossLeverClip;
            audioSource.Play();
            bossLever2 = true;
        }
        if (args.interactableObject.transform.CompareTag("BossLever3"))
        {
            Debug.Log("BossLever3");
            audioSource.clip = bossLeverClip;
            audioSource.Play();
            bossLever3 = true;
        }

    }
}
