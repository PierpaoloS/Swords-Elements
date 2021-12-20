using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FadeCircle : MonoBehaviour
{
    public bool isFading = false;
    private Animator anim;
    //public Animation circleFade;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fade(float speed)
    {
        //circleFade["CircleFade"].speed = speed;
        anim.SetTrigger("Fading");
    }
}
