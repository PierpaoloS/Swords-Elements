using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempWall : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(" Il muro ha colliso con: " + other.gameObject.name);
    }
}
