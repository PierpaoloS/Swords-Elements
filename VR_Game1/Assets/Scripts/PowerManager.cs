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
    public float iceSpawnDistance = 2f;
    private int numOfIce;
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
                ShootIce(5);
            }
        }
        

        //Testing dell'effetto della vita.
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool secondaryButtonValue);
        if (secondaryButtonValue == true)
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
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
    
    private void ShootIce( int numOfIce)
    {
        float angleStep = 10f;
        float radius = 5f;
        float angle = -30f;
        Vector3 playerPos = camDir.transform.position;
        Vector3 playerDirection = camDir.transform.forward;
        Vector3 spawnPos = playerPos + (playerDirection * iceSpawnDistance);
        Quaternion playerRotation = camDir.transform.rotation;
        float changePos = -0.5f;
        isIceBallShooted = true;
        for (int i = 1; i <= numOfIce; i++)
        {
            float iceDirXPos = spawnPos.x + Mathf.Sin((angle*Mathf.PI)/180) * radius;
            float iceDirZPos = spawnPos.z + Mathf.Cos((angle*Mathf.PI)/180) * radius;
            Vector3 iceVector = new Vector3(iceDirXPos, spawnPos.y, iceDirZPos);
            Vector3 iceMoveDirection = (iceVector - spawnPos).normalized * 10f;
            Rigidbody rb = Instantiate(IceBall, spawnPos + (camDir.transform.right * changePos) , playerRotation).GetComponent<Rigidbody>();
            rb.AddForce(iceMoveDirection, ForceMode.VelocityChange);
            angle += angleStep;
            changePos += 0.249f;
            Debug.Log("ChangePos: "+changePos);
            Debug.Log("rbTransform: "+ rb.transform.position);
        }
        Invoke("ResetIceBallCount", delayIceBall);
        
        //Vector3 spawnPos = playerPos + playerDirection * iceSpawnDistance;
        /*Vector3 spawnPos1 = playerPos + (camDir.transform.right * -2f) + (playerDirection * iceSpawnDistance);
        Vector3 spawnPos2 = playerPos + (camDir.transform.right * -1f) + (playerDirection * iceSpawnDistance);
        Vector3 spawnPos3 = playerPos + (playerDirection * iceSpawnDistance);
        Vector3 spawnPos4 = playerPos + (camDir.transform.right * 1f) + (playerDirection * iceSpawnDistance);
        Vector3 spawnPos5 = playerPos + (camDir.transform.right * 2f) + (playerDirection * iceSpawnDistance);
        Quaternion iceRotation = Quaternion.Euler(0f, -30f, 0f);
        Rigidbody rb1 = Instantiate(IceBall, spawnPos1, iceRotation).GetComponent<Rigidbody>();
        Rigidbody rb2 = Instantiate(IceBall, spawnPos2, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb3 = Instantiate(IceBall, spawnPos3 , playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb4 = Instantiate(IceBall, spawnPos4, playerRotation).GetComponent<Rigidbody>();
        Rigidbody rb5 = Instantiate(IceBall, spawnPos5 , playerRotation).GetComponent<Rigidbody>();
        isIceBallShooted = true;
        rb1.AddForce(playerDirection, ForceMode.VelocityChange);
        rb2.AddForce(playerDirection, ForceMode.VelocityChange);
        rb3.AddForce(playerDirection, ForceMode.VelocityChange);
        rb4.AddForce(playerDirection,  ForceMode.VelocityChange);
        rb5.AddForce(playerDirection, ForceMode.VelocityChange);
        Invoke("ResetIceBallCount", delayIceBall);*/
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
