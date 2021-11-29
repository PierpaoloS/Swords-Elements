using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAltar : MonoBehaviour
{
    public SwitchPower power;
    public float charge;
    public float maxCharge;
    public float increasingCharge;
    public Portal portal;
    public GameObject fireFlare;
    public GenerateEnemies generateEnemies;
    
    private void Start()
    {
        fireFlare.SetActive(false);
    }
    
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isFire)
        {
            if(charge < maxCharge)
            {
                fireFlare.SetActive(true);
                charge += increasingCharge * Time.deltaTime;
                Debug.Log("Siamo nel primo if, charge: "+charge);
                
            }
            else if(charge >= maxCharge)
            {
                Debug.Log("Attivazione altare fuoco");
                portal.isFire = true;
                generateEnemies.altarCounter += 1;
                fireFlare.SetActive(false);
            }
        }
        
    }
    
    public void OnTriggerExit(Collider other)
    {
       fireFlare.SetActive(false);
    }
}
