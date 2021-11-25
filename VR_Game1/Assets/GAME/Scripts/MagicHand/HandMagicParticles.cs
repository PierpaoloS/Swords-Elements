using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using PDollarGestureRecognizer;
using System.IO;
using UnityEngine.Events;
using System.Xml;
public class HandMagicParticles : MonoBehaviour
{
    public InputDevice targetDevice;
    public XRNode inputSource;
    public InputHelpers.Button inputButton;
    public float inputThreshold = 0.1f;
    
    public GameObject handParticles;
    
    //public ParticleSystem ps;
    //SwitchPower colorPower;
    void Start()
    {
        handParticles.SetActive(false);
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
        //ps = GetComponent<ParticleSystem>();
    }

    
    void Update()
    {
        //var main = ps.main;
        
        InputHelpers.IsPressed(InputDevices.GetDeviceAtXRNode(inputSource), inputButton, out bool isPressed, inputThreshold);
        if (isPressed)
        {
            handParticles.SetActive(true);
            /*if (colorPower != null)
            {
                if (colorPower.isIce == true)
                {
                    main.startColor = new Color(30,144,255);
                }
                
                else if (colorPower.isWind == true)
                {
                    main.startColor = new Color(224,255,255);
                }

                else if (colorPower.isEarth == true)
                {
                    main.startColor = new Color(46,139,87);
                }

                else if (colorPower.isFire == true)
                {
                    main.startColor = new Color(255,0,0);
                }
                else
                {
                    main.startColor = new Color(0,0,0);
                }
            }*/
        }
        
        if (!isPressed)
        {
            handParticles.SetActive(false);
        }
    }
}
