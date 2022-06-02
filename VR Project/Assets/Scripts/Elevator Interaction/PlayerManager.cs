using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{
    private bool electricity;
    private bool cardCheck;
    public GameObject hologramPrefab;
    private GameObject hologram;

    public AudioSource audioSource;
    public AudioClip leverClip;
    public AudioClip powerOnClip;
    public AudioClip hologramClip;
    public AudioClip wrongNumberClip;
    public AudioClip rightNumberClip;

    // Start is called before the first frame update
    void Start()
    {
        electricity = false;
        cardCheck = true;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (electricity)
        {
            GrapCard();
        }
    }


    public void OnPressNumber(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("RightNumber"))
        {
            Debug.Log("Right number pressed");
            audioSource.clip = rightNumberClip;
            audioSource.Play();
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

    public void GrapCard()
    {
        GameObject usim = GameObject.FindGameObjectWithTag("Slot");
        GameObject card = GameObject.FindGameObjectWithTag("Card");
        if (cardCheck)
        {
            if (Vector3.Distance(usim.transform.position, card.transform.position) < 0.1f)
            {
                Debug.Log("Hologram appear!");
                audioSource.clip = hologramClip;
                audioSource.Play();
                cardCheck = false;
                hologram = Instantiate(hologramPrefab, usim.transform.position + new Vector3(-0.1f, 0, 0), usim.transform.rotation);
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
        }
        if (args.interactableObject.transform.CompareTag("WrongLever"))
        {
            Debug.Log("Wrong Lever");
            audioSource.clip = leverClip;
            audioSource.Play();
        }
    }
}
