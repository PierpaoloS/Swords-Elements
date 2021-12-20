using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PowerManager : MonoBehaviour
{
    public InputDevice targetDevice;
    public GameObject cam;
    public GameObject camDir;
    public GameObject leftHand;
    public GameObject player;
    public SwitchPower power;
    public FadeCircle fadeCircle;

    //Audio Source Component
    public GameObject health1;
    public GameObject health2;
    
    
    //Player's variables
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarUI healthBar;
    public TakeDamageEffect takedamageeffect;
    public GameObject circle;
    
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
    public GameObject IceSpray;
    private bool isIceSprayShooted = false;
    public float damageIce = 10f;
    public float delayIceSpray;
    void Start()
    {
        power = player.GetComponent<SwitchPower>();
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

        StartCoroutine(addHealth());
        
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
        Invoke("GettingHand",2f);
    }

    void GettingHand()
    {
        circle = GameObject.FindWithTag("MagicCircle");
        fadeCircle = circle.GetComponent<FadeCircle>();
    }
    
    void Update()
    {
        if (currentHealth >= 100)
        {
            health1.SetActive(false);
            health2.SetActive(false);
        }
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

            if (power.isIce == true && isIceSprayShooted == false)
            {
                print("Ghiaccio: isIce: " + power.isIce + " isIceShooted: " + isIceSprayShooted);
                ShootIce();
            }
        }
    } 
    IEnumerator addHealth()
    {
        while (true)
        {
            if (currentHealth < 100)
            {
                if (currentHealth <= 30)
                {
                   health1.SetActive(true);
                   health2.SetActive(false);
                }
                else
                {
                    health1.SetActive(false);
                    health2.SetActive(true);
                }
                currentHealth += 10;
                yield return new WaitForSeconds(2);
            }
            else
            {
                yield return null;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Insect")
        {
            TakeDamage(10);
        }

        if (other.gameObject.tag == "Golem")
        {
            TakeDamage(45);
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
        //healthBar.SetHealth(currentHealth);
        takedamageeffect.ChangeAlphaValue();
    }

    private void Shoot()
    {
        //GameObject circle = GameObject.FindWithTag("MagicCircle");
     

        float posX = circle.transform.position.x;
        float posY = circle.transform.position.y;
        float posZ = circle.transform.position.z;
        //Rigidbody rb = Instantiate(FireBall, new Vector3(posX, posY, posZ), Quaternion.identity).GetComponent<Rigidbody>();
        var fireball = Instantiate(FireBall, new Vector3(posX, posY, posZ), Quaternion.identity);
        
        
        Rigidbody rb = fireball.GetComponent<Rigidbody>();
        isFireBallShooted = true;
        fadeCircle.Fade(0.6f);
        rb.AddForce(circle.transform.forward * 10f, ForceMode.VelocityChange);
        Invoke("ResetFireBallCount", delayFireBall);
    }
    
    private void ShootIce()
    {
       // GameObject circle = GameObject.FindWithTag("MagicCircle");

        float posX = circle.transform.position.x;
        float posY = circle.transform.position.y;
        float posZ = circle.transform.position.z;

        var iceSpray = Instantiate(IceSpray, new Vector3(posX, posY, posZ), Quaternion.identity);
        isIceSprayShooted = true;
        fadeCircle.Fade(0.5f);
        Destroy(iceSpray, 5f);
        Invoke("ResetIceBallCount", delayIceSpray);
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
        fadeCircle.Fade(0.7f);
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
        fadeCircle.Fade(0.7f);
        Destroy(cloneTornado, 7.0f);
        Invoke("ResetTornadoCounter", 7.0f);
    }
    private void ResetFireBallCount()
    {
        isFireBallShooted = false;
    }
    private void ResetIceBallCount()
    {
        isIceSprayShooted = false;
    }

    private void ResetWallCount()
    {
        isWallBuilt = false;
    }
    
    private void ResetTornadoCounter()
    {
        isTornadoBuilt = false;
    }

    private void Die()
    {
        SceneManager.LoadScene(5);
    }
}
