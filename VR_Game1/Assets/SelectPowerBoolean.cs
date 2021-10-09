using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class SelectPowerBoolean : MonoBehaviour
{
    public int value;
    public GameObject player;
    public SwitchPower powers;

    private void Start()
    {
        player.GetComponent<SwitchPower>();
    }
    
    
    public void SelectPower()
    {
        if(value == 1)
            SetEarthPower();
        if(value == 2)
            SetFirePower();
    }

    public void SetEarthPower()
    {
        powers.isEarth = true;
        powers.isFire = false;
        
    }
    
    public void SetFirePower()
    {
        powers.isEarth = false;
        powers.isFire = true;
    }
}
