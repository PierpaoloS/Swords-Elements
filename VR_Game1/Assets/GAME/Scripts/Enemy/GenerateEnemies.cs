using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.XR.Interaction.Toolkit;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject golem;
    public GameObject insect;
   /* public float xPosInsect;
    public float zPosInsect;
    public float xPosGolem;
    public float zPosGolem; */
    public int insectCount;
    public int golemCount;
    public int altarCounter;
    
    //Spawn Point Components
    public List<GameObject> spawnPoint = new List<GameObject>();
    private void Start()
    {
        StartCoroutine(InsectDrop());
        StartCoroutine(GolemDrop());
    }

    private void Update()
    {
        if(altarCounter >=3)
            StartSecondPhase();
    }

    public void StartSecondPhase()
    {
        StopCoroutine(InsectDrop());
        StopCoroutine(GolemDrop());
        StartCoroutine(SecondPhaseInsectDrop());
        StartCoroutine(SecondPhaseGolemDrop());
        
    }

    IEnumerator InsectDrop()
    {
        while (insectCount < 5)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(insect, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            insectCount += 1;
        }
    }

    IEnumerator GolemDrop()
    {
        while (golemCount < 2)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(golem, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(15f);
            golemCount += 1;
        }
    }
    
    IEnumerator SecondPhaseGolemDrop()
    {
        while (golemCount < 3)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(golem, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(10f);
            golemCount += 1;
        }
    }
   
    
    IEnumerator SecondPhaseInsectDrop()
    {
        while (insectCount < 8)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(insect, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            insectCount += 1;
        }
    }
}


