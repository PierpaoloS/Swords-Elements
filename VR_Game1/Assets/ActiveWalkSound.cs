using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class ActiveWalkSound : MonoBehaviour
{
    float oldPosX;
    float oldPosY;
    public GameObject audioSource;
    //private Vector2 stick;
    //private Vector2 check = Vector2.zero;
    //public InputDevice targetDevice;
    
    void Start()
    {
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;
        audioSource.SetActive(false);
        
        //List<InputDevice> devices = new List<InputDevice>();
        //InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        //InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
    }
    
    void Update()
    {
        /*targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis., out stick);
        Debug.Log("STICK: " + stick);
        if(stick != check)
        {
            audioSource.SetActive(true);
        }
        else
        {
            audioSource.SetActive(false);
        }*/
       
        if(oldPosX != transform.position.x || oldPosY != transform.position.y){
            audioSource.SetActive(true);
        }
        else
        {
            audioSource.SetActive(false);
        }
        oldPosX = transform.position.x;
        oldPosY = transform.position.y;
    }
}
