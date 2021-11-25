using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene(3);
    }
    public void Practise()
    {
        SceneManager.LoadScene(2);
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }
}
