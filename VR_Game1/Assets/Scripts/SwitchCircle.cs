using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCircle : MonoBehaviour
{
    public Sprite heartSprite;
    public Sprite fireSprite;
    public Sprite windSprite;
    public Sprite iceSprite;
    public GameObject leftHand;
    
    public SwitchPower power;
    
    private void Update()
    {
        if (power.isEarth)
        {
            SetHeartCircle();
        }

        if (power.isFire)
        {
            SetFireCircle();
        }

        if (power.isWind)
        {
           SetWindCircle();
        }
        if (power.isIce)
        {
            SetWindCircle();
        }
    }

    void SetHeartCircle()
    {
        leftHand.GetComponentInChildren<SpriteRenderer>().sprite = heartSprite;
        
    }

    void SetFireCircle()
    {
        leftHand.GetComponentInChildren<SpriteRenderer>().sprite = fireSprite;
    }

    void SetWindCircle()
    {
        leftHand.GetComponentInChildren<SpriteRenderer>().sprite = windSprite;
    }
    
    void SetIceCircle()
    {
        leftHand.GetComponentInChildren<SpriteRenderer>().sprite = iceSprite;
    }
}

