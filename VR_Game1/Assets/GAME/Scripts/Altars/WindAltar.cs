using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindAltar : MonoBehaviour
{
    public SwitchPower power;
    public float charge;
    public float maxCharge;
    public float increasingCharge;
    public Portal portal;
    public GameObject windFlare;
    public GenerateEnemies generateEnemies;
    private bool isAltarCounterIncreased = false;
    
    private void Start()
    {
        windFlare.SetActive(false);
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isWind)
        {
            if(charge < maxCharge)
            {
                windFlare.SetActive(true);
                charge += increasingCharge * Time.deltaTime;
                Debug.Log("Siamo nel primo if, charge: "+charge);
                
            }
            else if(charge >= maxCharge)
            {
                Debug.Log("Attivazione altare vento");
                portal.isWind = true;
                //hhhhh
                if (!isAltarCounterIncreased)
                {
                    generateEnemies.altarCounter += 1;
                    isAltarCounterIncreased = true;
                }
                
                windFlare.SetActive(false);
            }
        }
        
    }
    
    public void OnTriggerExit(Collider other)
    {
        windFlare.SetActive(false);
    }
}
