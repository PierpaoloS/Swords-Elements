using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IceSpray : MonoBehaviour
{
    private GameObject magicCircle;
    private void Start()
    {
        magicCircle = GameObject.FindWithTag("MagicCircle");
        Destroy(gameObject, 3f);
        
    }
    private void Update()
    {
        gameObject.transform.position = magicCircle.transform.position;
        gameObject.transform.forward = magicCircle.transform.forward;
    }
    
}
