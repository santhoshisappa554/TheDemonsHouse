using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    public float autoLoadLevelTimer;
    public static Level_Manager instance;

    private void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("LoadNextLevel", autoLoadLevelTimer);
        }

    }

    public void next()
    {
        SceneManager.LoadScene(4);
    }

    public void Quit()
    {
        Application.Quit();
    }
   
    public void LoadPreviousLevel(string name)
    {
        SceneManager.LoadScene(name);
        
    }
    public void LoadNextLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadPreviousLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
