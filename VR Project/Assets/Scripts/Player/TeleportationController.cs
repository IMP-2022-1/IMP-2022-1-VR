using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationController : MonoBehaviour
{
    [SerializeField]
    private ActionBasedController leftTeleportRay;

    [SerializeField]
    private float activationThreshold = 0.1f;

   
    // Update is called once per frame
    void Update()
    {
        if (leftTeleportRay)
        {
            bool activavted = CheckIfActivated(leftTeleportRay);
            leftTeleportRay.gameObject.SetActive(activavted);
        }    
    }

    public bool CheckIfActivated(ActionBasedController controller)
    {
        // get input from the controller (new input system)
        float value = controller.selectAction.action.ReadValue<float>();    // how much you press
        return value > activationThreshold;
    }
}
