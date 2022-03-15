using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.XR;

public class Tornado : MonoBehaviour
{
    public Transform tornadoCenter;
    public float pullForce;
    public float refreshRate;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Insect")
        {
            StartCoroutine(pullObject(other, true));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Insect")
        {
            StartCoroutine(pullObject(other, false));
        }
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
        else
        {
            Debug.Log("Reset Velocità");
            x.GetComponent<Rigidbody>().velocity = Vector3.zero;
            x.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            yield return refreshRate;
        }
    }
}
