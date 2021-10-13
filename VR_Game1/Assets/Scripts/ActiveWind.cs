using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWind : MonoBehaviour
{
    public GameObject player;
    public GameObject windCircle;
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
        SetCircleActive();
        Invoke("SetCircleNotActive",4);
    }

    public void SetWindPower()
    {
        print(" Sono in SetWindPower ");
        powers.isEarth = false;
        powers.isFire = false;
        powers.isWind = true;
    }

    public void SetCircleActive()
    {
        windCircle.SetActive(true);
    }
    public void SetCircleNotActive()
    {
        windCircle.SetActive(false);
    }
}
