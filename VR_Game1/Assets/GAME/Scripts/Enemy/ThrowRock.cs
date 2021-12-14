using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject rock;
    public GameObject golem;
    private Rigidbody rb;
    public bool isHoldingRock = false;
    //public ExplosionParticles explosionParticles;

    public void Update()
    {
        if (isHoldingRock && rb != null)
        {
            rb.position = spawnPoint.transform.position;
        }
    }

    public void SpawnRock()
    {
        Physics.IgnoreLayerCollision(3,9,true);
        rb = Instantiate(rock, spawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        isHoldingRock = true;
    }

    public void ThrowRocks()
    {
        isHoldingRock = false;
        Physics.IgnoreLayerCollision(3,9,false);
        if (rb != null)
        {
            rb.useGravity = true;
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        }
    }

    public void DestroyGolem()
    {
        Destroy(golem);
        //enemyAIGolem.DestroyEnemy();
    }
    
    
}
