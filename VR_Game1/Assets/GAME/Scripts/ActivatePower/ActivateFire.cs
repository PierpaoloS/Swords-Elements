using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFire : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject fireCircle;
    
  
    void Start()
    {
        print("Start Triangle");
        player.GetComponent<SwitchPower>();
    }

    public void OnEnable()
    {
        print("Si è attivato il triangle");
        SetFirePower();
        SetCircleActive();
        Invoke("SetCircleNotActive",4);
    }

    public void SetFirePower()
    {
        print("Sono in SetFirePower");
        powers.isEarth = false;
        powers.isIce = false;
        powers.isWind = false;
        powers.isFire = true;
    }

    public void SetCircleActive()
    {
        fireCircle.SetActive(true);
    }
    public void SetCircleNotActive()
    {
        fireCircle.SetActive(false);
    }
    
}
