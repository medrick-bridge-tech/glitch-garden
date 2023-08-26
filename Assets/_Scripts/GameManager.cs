using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompleteCanvas;
    [SerializeField] private Text _levelText;
    
    private LevelTimer _levelTimer;
    private int _numOfLiveAttackers;
    private LevelController _levelController;
    private int _currentLevel;


    void Awake()
    {
        // var numOfGameManagers = FindObjectsOfType<GameManager>().Length;
        // if (numOfGameManagers > 1)
        // {
        //     Destroy(gameObject);
        // }
        // else
        // {
        //     DontDestroyOnLoad(gameObject);
        // }
        
        _levelController = FindObjectOfType<LevelController>();
        
        _currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        var levelConfig = Resources.Load<LevelConfig>("Level" + _currentLevel);
        _levelController.SetLevelConfig(levelConfig);
        _levelText.text = $"Level {_currentLevel}";
    }

    void Start()
    {
        _levelTimer = FindObjectOfType<LevelTimer>();
    }

    public void StopSpawners()
    {
        var spawners = FindObjectsOfType<Spawner>();

        foreach (var spawner in spawners)
        {
            spawner.StopSpawning();
        }
    }

    public void AttackerSpawned()
    {
        _numOfLiveAttackers++;
    }

    public void AttackerDied()
    {
        _numOfLiveAttackers--;

        if (_levelTimer.timerFinished && _numOfLiveAttackers == 0)
        {
            HandleWinCondition();
        }
    }

    public void HandleWinCondition()
    {
        Time.timeScale = 0f;
        _levelCompleteCanvas.SetActive(true);
        PlayerPrefs.SetInt("CurrentLevel", _currentLevel + 1);
    }
}
