using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PowerManager : MonoBehaviour
{
    public InputDevice targetDevice;
    public GameObject cam;
    public GameObject camDir;
    public GameObject leftHand;
    public GameObject player;
    public SwitchPower power; 
    
    //Player's variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarUI healthBar;
    public TakeDamageEffect takedamageeffect;
    
    //Fireball's variables
    [Header("Fire Power")]
    public GameObject FireBall;
    private bool isFireBallShooted = false;
    public float damage = 10f;
    public float delayFireBall;
    

    //Wall's variables
    [Header("Earth Power")]
    public GameObject wall;
    public float wallSpawnDistance;
    private bool isWallBuilt = false;
    
    //Tornado's variables
    [Header("Tornado Power")]
    public GameObject tornado;
    private bool isTornadoBuilt = false;
    public float tornadoSpawnDistance;
    
    //Ice's variables
    [Header("Ice Power")]
    public GameObject IceBall;
    private bool isIceBallShooted = false;
    public float damageIce = 10f;
    public float delayIceBall;
    void Start()
    {
        power = player.GetComponent<SwitchPower>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
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

            if (power.isIce == true && isIceBallShooted == false)
            {
                print("Ghiaccio: isIce: " + power.isIce + " isIceShooted: " + isIceBallShooted);
                ShootIce();
            }
        }

        //Testing dell'effetto della vita.
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue == true)
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        takedamageeffect.ChangeAlphaValue();
    }

    private void Shoot()
    {
        GameObject circle = GameObject.FindWithTag("MagicCircle");
     

        float posX = circle.transform.position.x;
        float posY = circle.transform.position.y;
        float posZ = circle.transform.position.z;
        //Rigidbody rb = Instantiate(FireBall, new Vector3(posX, posY, posZ), Quaternion.identity).GetComponent<Rigidbody>();
        var fireball = Instantiate(FireBall, new Vector3(posX, posY, posZ), Quaternion.identity);
        
        
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        isFireBallShooted = true;
        rb.AddForce(circle.transform.forward * 10f, ForceMode.VelocityChange);
        Invoke("ResetFireBallCount", delayFireBall);
    }
    
    private void ShootIce()
    {
        
        Vector3 playerPos = camDir.transform.position;
        Vector3 playerDirection = camDir.transform.forward;
        Quaternion playerRotation = camDir.transform.rotation;
        
        Vector3 spawnPos = playerPos + playerDirection * wallSpawnDistance;
       
        Rigidbody rb1 = Instantiate(IceBall, spawnPos, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb2 = Instantiate(IceBall, spawnPos, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb3 = Instantiate(IceBall, spawnPos, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb4 = Instantiate(IceBall, spawnPos, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb5 = Instantiate(IceBall, spawnPos, playerRotation).GetComponent<Rigidbody>();
        isIceBallShooted = true;
        rb1.AddForce(playerDirection * -30f, ForceMode.VelocityChange);
        rb2.AddForce(playerDirection * -15f, ForceMode.VelocityChange);
        rb3.AddForce(playerDirection, ForceMode.VelocityChange);
        rb4.AddForce(playerDirection * 15f,  ForceMode.VelocityChange);
        rb5.AddForce(playerDirection * 30f, ForceMode.VelocityChange);
        Invoke("ResetIceBallCount", delayIceBall);
    }
    
    private void MagicWall()
    {
        Vector3 playerPos = camDir.transform.position;
        
        Vector3 playerDirection = camDir.transform.forward;
        Quaternion playerRotation = camDir.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * wallSpawnDistance;

        var cloneWall = Instantiate(wall, spawnPos, playerRotation);
        Debug.Log("Muro Spawnato");
        isWallBuilt = true;
        Destroy(cloneWall, 7.0f);
        Invoke("ResetWallCount", 7.0f);
    }
    
    private void MagicTornado()
    {
        Vector3 playerPos = camDir.transform.position;
        
        Vector3 playerDirection = camDir.transform.forward;
        Quaternion playerRotation = camDir.transform.rotation;
        Vector3 spawnPos = playerPos + playerDirection * tornadoSpawnDistance;

        var cloneTornado = Instantiate(tornado, spawnPos, playerRotation);
        
        isTornadoBuilt = true;
        Destroy(cloneTornado, 7.0f);
        Invoke("ResetTornadoCounter", 7.0f);
    }
    private void ResetFireBallCount()
    {
        isFireBallShooted = false;
    }
    private void ResetIceBallCount()
    {
        isIceBallShooted = false;
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
