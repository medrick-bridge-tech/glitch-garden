using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int _currentSceneIndex;
        
        
    void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                
        if (_currentSceneIndex == 0)
        {
            StartCoroutine(WaitAndLoadStartScene());
        }
    }
        
    IEnumerator WaitAndLoadStartScene()
    {
        yield return new WaitForSeconds(5);
        LoadNextScene();
    }

    public void LoadCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_currentSceneIndex);
    }
        
    public void LoadNextScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }
        
    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }

    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
}
