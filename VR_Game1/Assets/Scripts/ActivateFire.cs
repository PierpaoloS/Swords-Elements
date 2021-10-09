using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFire : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    void Start()
    {
        print("Start Triangle");
        player.GetComponent<SwitchPower>();
    }

    public void OnEnable()
    {
        print("Si è attivato il triangle");
        SetFirePower();
    }

    public void SetFirePower()
    {
        print("Sono in SetFirePower");
        powers.isEarth = false;
        powers.isFire = true;
    }
}
