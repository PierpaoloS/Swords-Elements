using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWind : MonoBehaviour
{
    public GameObject player;
    public GameObject windCircle;
    public SwitchPower powers;
     
    //GestioneCerchiMagici
    //private ActivateEarth earthCircleClone = new ActivateEarth();
    //private ActivateFire fireCircleClone = new ActivateFire();
    void Start()
    {
        print("Start Wave");
        player.GetComponent<SwitchPower>();
    }

    public void OnEnable()
    {
        print("Si è attivato il triangle");
        SetWindPower();
        AnimationPlay();
    }

    public void SetWindPower()
    {
        print(" Sono in SetWindPower ");
        powers.isEarth = false;
        powers.isFire = false;
        powers.isWind = true;
    }

    void AnimationPlay()
    {
        windCircle.SetActive(true);
        //earthCircleClone.earthCircle.SetActive(false);
        //fireCircleClone.fireCircle.SetActive(false);
    }
}
