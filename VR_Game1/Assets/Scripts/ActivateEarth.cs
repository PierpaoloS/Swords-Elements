using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEarth : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    void Start()
    {
        print("Start Square");
        player.GetComponent<SwitchPower>();
    }

    private void OnEnable()
    {
        print("Si è attivato lo Square");
        SetEarthPower();
    }

    public void SetEarthPower()
    {
        print("Sono in SetEarthPower");
        powers.isWind = false;
        powers.isEarth = true;
        powers.isFire = false;
    }
}
