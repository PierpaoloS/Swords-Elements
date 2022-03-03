using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject golem;
    public GameObject insect;
    public int insectCount;
    public int golemCount;
    public int altarCounter;
    private bool isSecondPhaseActivated = false;
    public bool isRunningInsect = false;
    public bool isRunningGolem = false;
    
    //Spawn Point Components
    public List<GameObject> spawnPoint = new List<GameObject>();
    private void Start()
    {
        insectCount = 0;
        golemCount = 0;
        StartCoroutine(InsectDrop());
        StartCoroutine(GolemDrop());
    }

    private void Update()
    {
        if (insectCount < 5 && !isSecondPhaseActivated && !isRunningInsect)
        {
            StartCoroutine(InsectDrop());
        }
        if (golemCount < 2 && !isSecondPhaseActivated && !isRunningGolem)
        {
            StartCoroutine(GolemDrop());
        }
        if (altarCounter >= 3 && !isSecondPhaseActivated)
        {
            StartSecondPhase();
            isSecondPhaseActivated = true;
        }
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
        isRunningInsect = true;
        while (insectCount < 5)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(insect, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            insectCount += 1;
        }
        isRunningInsect = false;
        Debug.Log("isRunningInsect: " + isRunningInsect);
    }

    IEnumerator GolemDrop()
    {
        isRunningGolem = true;
        while (golemCount < 2)
        {
            int i = Random.Range(0, 7);
            Vector3 spawnPosition = spawnPoint[i].transform.position;
            Instantiate(golem, new Vector3(spawnPosition.x, 1f, spawnPosition.z), Quaternion.identity);
            golemCount += 1;
            yield return new WaitForSeconds(15f);
        }
        isRunningGolem = false;
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


