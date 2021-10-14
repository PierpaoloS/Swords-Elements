using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCirclesManager : MonoBehaviour
{
    
    public SwitchPower powers;
    public GameObject handFireCircle;
    public GameObject handEarthCircle;
    public GameObject handWindCircle;
    public GameObject handIceCircle;
    //Guarda il GetChild e simili
    //public GameObject LeftHand;
    // Start is called before the first frame update
    void Start()
    {
        
        handFireCircle.SetActive(false);
        handEarthCircle.SetActive(false);
        handWindCircle.SetActive(false);
        handIceCircle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (powers.isFire == true)
        {
            handFireCircle.SetActive(true);
            handEarthCircle.SetActive(false);
            handWindCircle.SetActive(false);
            handIceCircle.SetActive(false);
        }

        if (powers.isEarth == true)
        {
            handFireCircle.SetActive(false);
            handEarthCircle.SetActive(true);
            handWindCircle.SetActive(false);
            handIceCircle.SetActive(false);
        }

        if (powers.isWind == true)
        {
            handFireCircle.SetActive(false);
            handEarthCircle.SetActive(false);
            handWindCircle.SetActive(true);
            handIceCircle.SetActive(false);
        }

        if (powers.isIce == true)
        {
            handFireCircle.SetActive(false);
            handEarthCircle.SetActive(false);
            handWindCircle.SetActive(false);
            handIceCircle.SetActive(true);
        }

    }

}

