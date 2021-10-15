using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandCirclesManager : MonoBehaviour
{
    
    public SwitchPower powers;
    public Sprite handFireCircle;
    public Sprite circle;
    public Sprite handEarthCircle;
    public Sprite handWindCircle;
    public Sprite handIceCircle;
  
    void Awake()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {

        if (powers.isFire == true)
        {
            circle = handFireCircle;
        }

        if (powers.isEarth == true)
        {
            circle = handEarthCircle;
        }

        if (powers.isWind == true)
        {
            circle = handWindCircle;
        }

        if (powers.isIce == true)
        {
            circle = handIceCircle;
        }

    }

}

