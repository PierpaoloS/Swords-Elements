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
    void Start()
    {
        //GameObject circle = GameObject.FindWithTag("MagicCircle");
    }
    /*void Update()
    {
        
        Debug.Log("Charge: " + charge);
        if(isActive && charge < maxCharge)
         {
             charge += increasingCharge * Time.deltaTime;
             Debug.Log("Siamo nel primo if");
         }
         else if(charge >= maxCharge)
         {
             Debug.Log("Attivazione del portale");
         }
        
    }
    */

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isFire)
        {
            if(charge < maxCharge)
            {
                charge += increasingCharge * Time.deltaTime;
                Debug.Log("Siamo nel primo if, charge: "+charge);
                
            }
            else if(charge >= maxCharge)
            {
                Debug.Log("Attivazione del portale");
            }
        }
        
    }
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isFire)
        {
            isActive = true;
        }
    }*/
    /*public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MagicCircle" && power.isFire)
        {
            isActive = false;
        }
    }*/
}
