using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.XR;
public class TornadoSpawner : MonoBehaviour
{
    private InputDevice targetDevice;
    public GameObject tornado;
    public GameObject player;
    public float spawnDistance;
    private bool isTornadoBuilt = false;

    
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
    
    }
    void Update()
    {
        //Bottone X
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue && isTornadoBuilt == false)
        {
            MagicTornado();
        }
    }
    
    private void MagicTornado()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 playerDirection = player.transform.forward;
        Quaternion playerRotation = player.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
        // Debug.Log("Grilletto Premuto!!!");
        Instantiate(tornado, spawnPos, playerRotation);
        isTornadoBuilt = true;
        Invoke("ResetTornadoCounter", 5.0f);
    }

    private void ResetTornadoCounter()
    {
        //Destroy(tornado);
        isTornadoBuilt = false;
    }
}
