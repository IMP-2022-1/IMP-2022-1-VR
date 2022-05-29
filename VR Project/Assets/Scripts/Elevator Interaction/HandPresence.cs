using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice; // store device we use

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

        /*foreach (InputDevice dev in devices)
        {
            Debug.Log(dev.name + " " + dev.characteristics);
        }*/

        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            // instantiate controller prefab
            GameObject controller = controllerPrefabs.Find(ctrl => ctrl.name == targetDevice.name); // 모든 리스트 돌면서 controller.name하고 targerDevice.name하고 매칭해보고 맞으면 return 값으로 돌려준다.

            if (controller != null)
            {
                spawnedController = Instantiate(controller, transform);
            }
            else
            {
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }
        }

        if(spawnedHand == null)
        {
            // spawn the hand
            spawnedHand = Instantiate(handModelPrefab, transform);  // 그냥 transform

            // get an animator
            handAnimator = spawnedHand.GetComponent<Animator>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*// TestInputs();

        // set controller / hand active/deactive
        spawnedHand.SetActive(!showController);
        spawnedController.SetActive(showController);

        // update hand animation if not showing controller
        if (!showController)
        {
            UpdateHandAnimation();
        }
*/
        if (targetDevice == null || !targetDevice.isValid)
        {
            TryInitialize();
        }
        else
        {
            // TestInputs();

            // set controller / hand active/deactive
            spawnedHand.SetActive(!showController);
            spawnedController.SetActive(showController);

            // update hand animation if not showing controller
            if (!showController)
            {
                UpdateHandAnimation();
            }
        }
    }

    private void UpdateHandAnimation()
    {
        // trigger pressed
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
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

        if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool pressed))
        {
            Debug.Log("Primary pressed: " + pressed);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("Trigger value: " + triggerValue);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed))
        {
            Debug.Log("Trigger Pressed: " + triggerPressed);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            Debug.Log("Grip value: " + gripValue);
        }
        if (targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisValue))   // primary : right hand, secondary : left hand
        {
            Debug.Log("Joystick value: " + axisValue);
        }
    }
}
