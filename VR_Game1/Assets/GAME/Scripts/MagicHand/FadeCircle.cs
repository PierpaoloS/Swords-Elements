using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FadeCircle : MonoBehaviour
{
    public bool isFading = false;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isFading)
            Debug.Log("TRIGGERED iSFading");
            anim.SetTrigger("Fading");
    }
}
