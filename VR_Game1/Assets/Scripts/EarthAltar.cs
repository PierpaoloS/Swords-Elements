using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthAltar : MonoBehaviour
{
    public SwitchPower power;
    public float charge;
    public float maxCharge;
    public float increasingCharge;
    public Portal portal;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isEarth)
        {
            if(charge < maxCharge)
            {
                charge += increasingCharge * Time.deltaTime;
                Debug.Log("Siamo nel primo if, charge: "+charge);
                
            }
            else if(charge >= maxCharge)
            {
                Debug.Log("Attivazione Altare terra");
                portal.isEarth = true;
            }
        }
        
    }
}
