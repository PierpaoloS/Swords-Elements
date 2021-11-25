using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager : MonoBehaviour 
{
    public ParticleSystem explosion;
    public GameObject fireBall;
    void Start()
    {
        Destroy(fireBall,8f);
    }
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "MagicCircle" && other.gameObject.tag != "MainCamera" && other.gameObject.tag != "Sword")
        {
            Destroy(fireBall);
            explosion.Play();
            Destroy(gameObject,1f);
        }
    }
}
