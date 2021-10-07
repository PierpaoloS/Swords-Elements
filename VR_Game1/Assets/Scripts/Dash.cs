using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Dash : MonoBehaviour
{
    public InputDevice targetDevice;
    public float dashForce;
    public bool isDashing = false;
    public float delayDashing;
    public GameObject vrRig;
    public Camera cam;

    public GameObject dashEffect;
    
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics,devices);

        foreach (var item in devices)
        {
            // Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        //BOTTONE A
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
		
        if (primaryButtonValue && isDashing == false)
        {
            Dashing();
        }
    }

    private void Dashing()
    {
        vrRig.GetComponent<Rigidbody>().AddForce(cam.transform.forward * dashForce, ForceMode.Impulse);
        Invoke("resetDashingCount", delayDashing);
    }

    private void resetDashingCount()
    {
        isDashing = false;
    }

   
}
