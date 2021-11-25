using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    private InputDevice targetDevice;
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics,devices);

        foreach (var item in devices)
        {
            //Debug.Log(item.name + item.characteristics);
        }
        
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Bottone X
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue)
        {
           // Debug.Log("Primary Button Pressed - X PREMUTO");
        }
        
        //Bottone Y
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue)
        {
           // Debug.Log("Secondary Button Pressed - Y PREMUTO");
        }
        
        //Trigger Principale
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
        if (triggerValue > 0.1f)
        {
           // Debug.Log("Grilletto Premuto!!!");
        }
    }
}
