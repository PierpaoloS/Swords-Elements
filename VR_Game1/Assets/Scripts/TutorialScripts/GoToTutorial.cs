using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTutorial : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    { 
        SceneManager.LoadScene(1);
    }
}
