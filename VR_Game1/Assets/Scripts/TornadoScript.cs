using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;

public class TornadoScript : MonoBehaviour
{
    public Transform tornadoCenter;
    public float pullForce;
    public float refreshRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(pullObject(other, true));
        }
        //throw new NotImplementedException();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            StartCoroutine(pullObject(other, false));
        }

        //throw new NotImplementedException();
    }

    IEnumerator pullObject(Collider x, bool shouldPull)
    {
        if (shouldPull)
        {
            Vector3 ForceDir = tornadoCenter.position - x.transform.position;
            x.GetComponent<Rigidbody>().AddForce(ForceDir.normalized * pullForce * Time.deltaTime);
            yield return refreshRate;
            StartCoroutine(pullObject(x, shouldPull));
        }
    }
}
