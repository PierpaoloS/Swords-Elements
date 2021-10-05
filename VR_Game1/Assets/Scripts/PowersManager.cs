using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PowersManager : MonoBehaviour
{
    private InputDevice targetDevice;
    private bool wallPower;
    WallSpawner wallSp = new WallSpawner();
    
    
    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        wallPower = false;
    }

    // Update is called once per frame
    public void Update()
    {
        //premuto il bottone X dovrebbe spawnare il muro
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue  && wallPower == true)
        {
            Debug.Log("Premuto Bottone X");
            //testing lo spawn del wall
           // wallSp.MagicWall();
        }
    }

    public void ChangeWallspValue()
    {
        wallPower = true;
        Debug.Log("Settato il valore variabile ChangeWall: " + wallPower);
    }
}
