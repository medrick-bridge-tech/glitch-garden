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
    private int _aliveAttackersCount;
    private LevelController _levelController;
    private int _currentLevel;


    void Awake()
    {
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
        var attackerSpawners = FindObjectsOfType<AttackerSpawner>();

        foreach (var attackerSpawner in attackerSpawners)
        {
            attackerSpawner.StopSpawning();
        }
    }

    public void AttackerSpawned()
    {
        _aliveAttackersCount++;
    }

    public void AttackerDied()
    {
        _aliveAttackersCount--;

        if (_levelTimer.IsTimerFinished && _aliveAttackersCount == 0)
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
