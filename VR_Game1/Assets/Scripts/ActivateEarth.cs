using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEarth : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject earthCircle;
    //public Animation anim;
    void Start()
    {
        print("Start Square");
        player.GetComponent<SwitchPower>();
        StartCoroutine(Wait());
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
        Wait();
        earthCircle.SetActive(false);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }
}
