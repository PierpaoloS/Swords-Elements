using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRock : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject rock;
    
    public void SpawnRock()
    {
        Physics.IgnoreLayerCollision(3,9,true);
        Rigidbody rb = Instantiate(rock, spawnPoint.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Debug.Log(" SpawnRock ");
    }

    public void ThrowRocks( GameObject stone)
    {
        Rigidbody rb = stone.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
        Physics.IgnoreLayerCollision(3,9,false);
    }
}
