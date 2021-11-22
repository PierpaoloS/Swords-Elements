using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectAttack : MonoBehaviour
{
    public GameObject insect;
    public PowerManager power;
    public bool isEnemyHitted;
    void Start()
    {
        Collider collider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && isEnemyHitted == false)
        {
            Debug.Log("Sei stato colpito");
            power.TakeDamage(25);
            isEnemyHitted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isEnemyHitted = false;
    }
}
