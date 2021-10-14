using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PowerManager : MonoBehaviour
{
    public InputDevice targetDevice;
    public GameObject cam;
    public GameObject leftHand;
    public GameObject player;
    public GameObject vrRig;
    public SwitchPower power; 
   
    
    //Fireball's variables
    public GameObject FireBall;
    private bool isFireBallShooted = false;
    public float damage = 10f;
    public float delayFireBall;

    //Wall's variables
    public GameObject wall;
    public float wallSpawnDistance;
    private bool isWallBuilt = false;
    
    //Tornado's variables
    public GameObject tornado;
    private bool isTornadoBuilt = false;
    
    void Start()
    {
        power = player.GetComponent<SwitchPower>();
        
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
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);
        if (primaryButtonValue == true)
        {
            if (power.isFire == true && isFireBallShooted == false)
            {
                print("Fuoco: isFire:" + power.isFire + " isFireBallShooted: " + isFireBallShooted);
                Shoot();
            }

            if (power.isEarth == true && isWallBuilt == false)
            {
                print("Terra: isEarth: " + power.isEarth + " isWallBuilt: " + isWallBuilt);
                MagicWall();
            }
            
            if (power.isWind == true && isTornadoBuilt == false)
            {
                print("Vento: isWind: " + power.isWind + " isTornadoBuilt: " + isTornadoBuilt);
                MagicTornado();
            }
                
        }
    }

    

    private void Shoot()
    {
        GameObject circle = GameObject.FindWithTag("MagicCircle");

        float posX = circle.transform.position.x;
        float posY = circle.transform.position.y;
        float posZ = circle.transform.position.z;
        Rigidbody rb = Instantiate(FireBall, new Vector3(posX, posY, posZ), Quaternion.identity).GetComponent<Rigidbody>();
        isFireBallShooted = true;
        rb.AddForce(circle.transform.forward * 10f, ForceMode.VelocityChange);
        Invoke("ResetFireBallCount", delayFireBall);
    }

    private void MagicWall()
    {
        float dirX = vrRig.transform.forward.x;
        float dirY = player.transform.forward.y;
        float dirZ = vrRig.transform.forward.z * wallSpawnDistance;

        Vector3 playerPos = cam.transform.position;
        Vector3 playerDirection = new Vector3(dirX, dirY, dirZ);
        //Quaternion playerRotation = cam.transform.rotation;
        Quaternion playerRotation = Quaternion.Euler(vrRig.transform.rotation.x,cam.transform.rotation.y, vrRig.transform.rotation.z);
        Vector3 spawnPos = playerPos + playerDirection;

        var cloneWall = Instantiate(wall, spawnPos, playerRotation);
        Debug.Log("Muro Spawnato");
        isWallBuilt = true;
        Destroy(cloneWall, 7.0f);
        
        Invoke("ResetWallCount", 7.0f);
    }
    
    private void MagicTornado()
    {
        Vector3 playerPos = cam.transform.position;
        Vector3 playerDirection = cam.transform.forward;
        Quaternion playerRotation = cam.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * wallSpawnDistance;
        Instantiate(tornado, spawnPos, playerRotation);
        isTornadoBuilt = true;
        //Destroy(tornado, 7.0f);
        Invoke("ResetTornadoCounter", 5.0f);
    }
    private void ResetFireBallCount()
    {
        isFireBallShooted = false;
    }

    private void ResetWallCount()
    {
        isWallBuilt = false;
    }
    
    private void ResetTornadoCounter()
    {
        isTornadoBuilt = false;
    }
}
