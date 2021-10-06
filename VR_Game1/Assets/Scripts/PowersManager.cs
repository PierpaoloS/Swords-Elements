using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PowersManager : MonoBehaviour
{
    private InputDevice targetDevice;
    public GameObject cam;
    public GameObject player;
    public GameObject leftHand;
    SwitchPowersValue powers = new SwitchPowersValue();
    
    ////////////// RockWall Superpower //////////////////
    //private bool wallPower = false;
    public GameObject wall;
    float spawnDistance = 5.0f;
    private bool isWallBuilt = false;
    
    /////////// FireBall Superpower /////////////////
    //private bool firePower = false;
    public GameObject fireBall;
    private bool isFireBallShooted = false;
    public float damage = 10f;
    public float delayFireBall;
    

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
         
    }

    // Update is called once per frame
    public void Update()
    {
        //premuto il bottone X dovrebbe spawnare il muro
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        
        if (primaryButtonValue)
        {
            MagicWall();
            Debug.Log("Premuto bottone X");
            if (powers.wallPower == true)
            {
                MagicWall();
            }

            if (powers.firePower == true)
            {
                Shoot();
            }
        }
    }

    
    ////////////// Wall Superpower //////////////////
   /* public void ChangeWallspValue()
    {
        firePower = false;
        wallPower = true;
    }*/
    public void MagicWall()
    {
        float dirX = cam.transform.forward.x;
        float dirY = player.transform.forward.y;
        float dirZ = cam.transform.forward.z * spawnDistance;
        Vector3 playerPos = cam.transform.position;
        Vector3 playerDirection = new Vector3(dirX, dirY,dirZ);  //player.transform.forward; 
        Quaternion playerRotation = cam.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection;
        if (isWallBuilt == false)
        {
            var cloneWall = Instantiate(wall, spawnPos, playerRotation);
            Debug.Log("Muro Spownato");
            isWallBuilt = true;
            Destroy(cloneWall, 7.0f);
        }
        Invoke("ResetWallCounter", 7.0f);
    }
    private void ResetWallCounter()
    {
        // Destroy(wall);
        isWallBuilt = false;
        
    }
    
    ////////// FireBall Superpower ////////////////////
    /*public void ChangeFirePowerValue()
    {
        wallPower = false;
        firePower = true;
    }*/
    private void Shoot()
    {
        GameObject circle = GameObject.FindWithTag("MagicCircle");
        float posX = circle.transform.position.x;
        float posY = circle.transform.position.y;
        float posZ = circle.transform.position.z;
        Rigidbody rb = Instantiate(fireBall, new Vector3(posX, posY, posZ), Quaternion.identity).GetComponent<Rigidbody>();
        isFireBallShooted = true;
        rb.AddForce(circle.transform.forward * 10f, ForceMode.VelocityChange);
        Invoke("resetFireBallCount", delayFireBall);

    }
    private void resetFireBallCount()
    {
        isFireBallShooted = false;
    }
}
