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
        AnimationPlay();
    }

    public void SetFirePower()
    {
        print("Sono in SetFirePower");
        powers.isEarth = false;
        powers.isWind = false;
        powers.isFire = true;
    }
    IEnumerator AnimationPlay()
    {
        fireCircle.SetActive(true);
        yield return new WaitForSeconds(5);
        fireCircle.SetActive(false);
    }
    
}
