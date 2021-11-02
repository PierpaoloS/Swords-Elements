using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Windows.WebCam;

public class TransformManager : MonoBehaviour
{
    private float rotX;
    private float rotY;
    private float rotZ;
    
    public GameObject vrRig;

    public GameObject cam;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rotX = vrRig.transform.eulerAngles.x;
        rotY = cam.transform.eulerAngles.y;
        rotZ = vrRig.transform.eulerAngles.z;

        this.transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
    }
}
