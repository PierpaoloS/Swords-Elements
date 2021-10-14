using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIce : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    public GameObject iceCircle;
    
  
    void Start()
    {
        print("Start Inverse Triangle");
        player.GetComponent<SwitchPower>();
    }

    public void OnEnable()
    {
        print("Si è attivato l' inverse triangle");
        SetIcePower();
        SetCircleActive();
        Invoke("SetCircleNotActive",4);
    }

    public void SetIcePower()
    {
        print("Sono in SetIcePower");
        powers.isEarth = false;
        powers.isWind = false;
        powers.isFire = false;
        powers.isIce = true;
    }

    public void SetCircleActive()
    {
        iceCircle.SetActive(true);
    }
    public void SetCircleNotActive()
    {
        iceCircle.SetActive(false);
    }
}
