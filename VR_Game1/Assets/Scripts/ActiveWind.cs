using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWind : MonoBehaviour
{
    public GameObject player;
    public SwitchPower powers;
    void Start()
    {
        print("Start Wave");
        player.GetComponent<SwitchPower>();
    }

    public void OnEnable()
    {
        print("Si è attivato il triangle");
        SetWindPower();
    }

    public void SetWindPower()
    {
        print(" Sono in SetWindPower ");
        powers.isEarth = false;
        powers.isFire = false;
        powers.isWind = true;
    }
}
