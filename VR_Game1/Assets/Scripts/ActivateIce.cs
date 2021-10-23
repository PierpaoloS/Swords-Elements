using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateIce : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject IceCircle;

    private void Start()
    {
        player.GetComponent<SwitchPower>();
    }

    private void OnEnable()
    {
        SetWaterPower();
        SetCircleActive();
        Invoke("SetCircleNotActive", 4);
    }

    public void SetWaterPower()
    {
        powers.isEarth = false;
        powers.isFire = false;
        powers.isWind = false;
        powers.isIce = true;
    }

    public void SetCircleActive()
    {
        IceCircle.SetActive(true);
    }

    public void SetCircleNotActive()
    {
        IceCircle.SetActive(false);
    }
}