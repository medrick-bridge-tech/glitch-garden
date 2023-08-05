using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
     public float loadScreen;
        void Start()
        {
            Invoke("LoadNextLevel", loadScreen);
        }
    
        public void LoadLevel(string name)
        {
            Debug.Log("load next level" + name);
            Application.LoadLevel(name);
        }
        private void LoadNextLevel()
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }

}
