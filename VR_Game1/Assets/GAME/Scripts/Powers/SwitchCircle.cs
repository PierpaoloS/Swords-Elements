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

    public bool isDelaying;
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
            SetIceCircle();
        }
    }

    void SetHeartCircle()
    {
        leftHand.GetComponentInChildren<SpriteRenderer>().sprite = heartSprite;
        //leftHand.GetComponentInChildren<Image>().sprite
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

