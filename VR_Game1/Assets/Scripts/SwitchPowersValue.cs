
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPowersValue : MonoBehaviour
{
    public bool wallPower = false;
    public bool firePower = true;

    public void ChangeFirePowerValue()
    {
        wallPower = false;
        firePower = true;
        Debug.Log("Cambiato valore FIRE");
    }
    public void ChangeWallPowerValue()
    {
        firePower = false;
        wallPower = true;
        Debug.Log("Cambiato valore WALL");
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
