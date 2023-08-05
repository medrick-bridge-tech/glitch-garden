using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
        [SerializeField] float loadScreen;
        void Start()
        {
            Invoke("LoadNextLevel", loadScreen);
        }
    
        private void LoadLevel(string name)
        {
             Debug.Log("load next level" + name);
             SceneManager.LoadScene(name);
        }
        private void LoadNextLevel()
        {
            SceneManager.LoadScene(Application.loadedLevel + 1);
        }

}
