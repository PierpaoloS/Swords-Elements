
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPowersValue : MonoBehaviour
{
    public bool wallPower = false;
    public bool firePower = false;

    public void ChangeFirePowerValue()
    {
        wallPower = false;
        firePower = true;
        Debug.Log("Cambiato valore WALL");
    }
    public void ChangeWallspValue()
    {
        firePower = false;
        wallPower = true;
        Debug.Log("Cambiato valore FIRE");
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
