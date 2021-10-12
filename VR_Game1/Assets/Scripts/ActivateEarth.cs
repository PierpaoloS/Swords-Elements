using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEarth : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject earthCircle;
    
    
    //GestioneCerchiMagici
    //private ActivateFire fireCircleClone = new ActivateFire();
   // private ActiveWind windCircleClone = new ActiveWind();
    
    void Start()
    {
        print("Start Square");
        player.GetComponent<SwitchPower>();
    }

    private void OnEnable()
    {
        print("Si è attivato lo Square");
        SetEarthPower();
        AnimationPlay();
    }

    public void SetEarthPower()
    {
        print("Sono in SetEarthPower");
        powers.isWind = false;
        powers.isEarth = true;
        powers.isFire = false;
    }
    public void AnimationPlay()
    {
        earthCircle.SetActive(true);
        //fireCircleClone.fireCircle.SetActive(false);
        //windCircleClone.windCircle.SetActive(false);
    }
}
