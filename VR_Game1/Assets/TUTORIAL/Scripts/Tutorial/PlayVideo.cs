using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
    public GameObject videoPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    { 
        videoPlayer.SetActive(true);
    }
}
