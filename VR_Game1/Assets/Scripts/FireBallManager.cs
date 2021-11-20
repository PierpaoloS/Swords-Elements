using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager : MonoBehaviour
{
    public ParticleSystem explosion;
    
    void Start()
    {
        Destroy(gameObject,8f);
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Player" && other.gameObject.tag != "MagicCircle" && other.gameObject.tag != "MainCamera")
        {
            explosion.Play();
            Destroy(gameObject,0.3f);
        }
    }
}
