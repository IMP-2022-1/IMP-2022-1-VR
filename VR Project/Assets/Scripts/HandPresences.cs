using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresences : MonoBehaviour
{

    private InputDevice targetDevice;

    [SerializeField]
    private List<GameObject> controllerPrefabs;

    [SerializeField]
    private InputDeviceCharacteristics controllerCharacteristics;


    private GameObject spawnedController;


    [SerializeField]
    private bool showController = false;

    [SerializeField]
    private GameObject handModelPrefab;

    private GameObject spawnedHand;

    private Animator handAnimator;  


    // Start is called before the first frame update
    void Start()
    {
        TryInitialize();  

    }

    private void TryInitialize()
    {
        List<InputDevice> devices = new List<InputDevice>();

        //InputDeviceCharacteristics chars = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller; 

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (InputDevice dev in devices)
          {
              Debug.Log(dev.name + " " + dev.characteristics);
          }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            // instantiate controller prefab
            /*GameObject controller = controllerPrefabs.Find(ctrl => ctrl.name == targetDevice.name);

            if (controller != null)
            {
                spawnedController = Instantiate(controller, transform);
            }
            else
            {
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }*/

        }

        // spawn the hand
        //spawnedHand = Instantiate(handModelPrefab, transform);

        // get an animator
        //handAnimator = spawnedHand.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!targetDevice.isValid)
        {
            TryInitialize();
        }
        TestInputs();
    }

    private void UpdateHandAnimation( )
    {
        // trigger pressed
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("trigger On");
            handAnimator.SetFloat("Trigger", triggerValue);
        } else {
            handAnimator.SetFloat("Trigger",0);
        }

        // grip pressed
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }


    }

    private void TestInputs()
    {
        if (targetDevice == null) return;

        /*if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            Debug.Log("Primary pressed: " + pressed);
        }*/

        /*if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue)) 
        {
            Debug.Log("Trigger value: " + triggerValue);
        }*/

        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed))
        {
            Debug.Log("Trigger presssed: " + triggerPressed);
            
        }

        /*if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            Debug.Log("Grip value: " + gripValue);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue))
        {
            Debug.Log("Joystick: " + axisValue);
        }*/


    }

}
