using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallManager : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Destroy(this,3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
