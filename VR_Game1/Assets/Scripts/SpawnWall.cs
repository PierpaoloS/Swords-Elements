using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SpawnWall : MonoBehaviour
{
	private InputDevice targetDevice;
	//private Animation anim;
   	public GameObject wall;
    public GameObject player;
    public float spawnDistance;
    private bool isWallBuilt = false;

    
    void Start()
    {
	    List<InputDevice> devices = new List<InputDevice>();
	    InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
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
    private void Update()
    {
	    targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
		
	    if (triggerValue > 0.1f && isWallBuilt == false)
	    {
		    MagicWall();
		    
	    }
	    
    }
    
    private void MagicWall()
    {
			
		    Vector3 playerPos = player.transform.position;
		    Vector3 playerDirection = player.transform.forward;
		    Quaternion playerRotation = player.transform.rotation;
		    Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
		   // Debug.Log("Grilletto Premuto!!!");
		    
		    Instantiate(wall, spawnPos, playerRotation);
		    isWallBuilt = true;
		    Invoke("ResetWallCounter", 5.0f);
    }

    private void ResetWallCounter()
    {
	    isWallBuilt = false;
    }
}
