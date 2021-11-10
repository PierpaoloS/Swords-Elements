using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isFire;
    public bool isWind;
    public bool isIce;
    public bool isEarth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFire && isEarth && isIce && isWind)
        {
            Debug.Log("Portale Attivato!");
        }
    }
}
