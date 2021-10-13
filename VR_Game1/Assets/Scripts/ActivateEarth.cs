using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEarth : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject earthCircle;
    
    
    void Start()
    {
       
        print("Start Square");
        player.GetComponent<SwitchPower>();
    }

    private void OnEnable()
    {
        print("Si è attivato lo Square");
        SetEarthPower();
        SetCircleActive();
        Invoke("SetCircleNotActive",4);
    }

    public void SetEarthPower()
    {
        print("Sono in SetEarthPower");
        powers.isWind = false;
        powers.isEarth = true;
        powers.isFire = false;
    }
    public void SetCircleActive()
    {
        earthCircle.SetActive(true);
    }
    public void SetCircleNotActive()
    {
        earthCircle.SetActive(false);
        Debug.Log(" Setto a false Oggetto Magic Power Circle");
    }
    

    
}
