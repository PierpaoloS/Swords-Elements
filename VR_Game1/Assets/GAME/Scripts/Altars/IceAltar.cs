using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class IceAltar : MonoBehaviour
{
    public SwitchPower power;
    public float charge;
    public float maxCharge;
    public float increasingCharge;
    public Portal portal;
    public GameObject iceFlare;
    public GenerateEnemies generateEnemies;
    private bool isAltarCounterIncreased = false;
    private void Start()
    {
        iceFlare.SetActive(false);
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isIce)
        {
            if(charge < maxCharge)
            {
                iceFlare.SetActive(true);
                charge += increasingCharge * Time.deltaTime;
                Debug.Log("Siamo nel primo if, charge: "+charge);

            }
            else if(charge >= maxCharge)
            {
                Debug.Log("Attivazione altare ghiaccio");
                portal.isIce = true;
                if (!isAltarCounterIncreased)
                {
                    generateEnemies.altarCounter += 1;
                    isAltarCounterIncreased = true;
                }
                iceFlare.SetActive(false);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        iceFlare.SetActive(false);
    }
}
