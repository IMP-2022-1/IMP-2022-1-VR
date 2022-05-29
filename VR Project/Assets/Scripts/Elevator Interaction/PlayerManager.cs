using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerManager : MonoBehaviour
{
    private bool cardCheck;
    public GameObject hologramPrefab;
    private GameObject hologram;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        cardCheck = true;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        GripCard();
    }


    public void OnPressNumber(SelectEnterEventArgs args)
    {
        if (args.interactableObject.transform.CompareTag("2"))
        {
            Debug.Log("Correct number pressed");
        }
        if (args.interactableObject.transform.CompareTag("1"))
        {
            Debug.Log("Wrong number pressed");
        }
        if (args.interactableObject.transform.CompareTag("3"))
        {
            Debug.Log("Wrong number pressed");
        }
    }

    public void OnGrabCard(SelectEnterEventArgs args)
    {
        GameObject usim = GameObject.FindGameObjectWithTag("Slot");
        GameObject card = GameObject.FindGameObjectWithTag("Card");
        if (args.interactableObject.transform.CompareTag("Card"))
        {
            if (Vector3.Distance(usim.transform.position, card.transform.position) < 0.01)
            {
                Debug.Log("Card insert!");
            }
        }

    }

    private void OnTriggerEnter(Collider collider)
    {
    }

    public void GripCard()
    {
        GameObject usim = GameObject.FindGameObjectWithTag("Slot");
        GameObject card = GameObject.FindGameObjectWithTag("Card");
        if (cardCheck)
        {
            if (Vector3.Distance(usim.transform.position, card.transform.position) < 0.1f)
            {
                Debug.Log("Card insert!");
                cardCheck = false;
                hologram = Instantiate(hologramPrefab, usim.transform.position + new Vector3(-0.1f, 0, 0), usim.transform.rotation);
            }
        }
    }
}
