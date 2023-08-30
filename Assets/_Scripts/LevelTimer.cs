using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private bool _timerFinished;
    private Slider _levelTimerSlider;
    private LevelController _levelController;
    private GameManager _gameManager;

    public bool TimerFinished => _timerFinished;


    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _levelController = FindObjectOfType<LevelController>();
        _levelTimerSlider = GetComponent<Slider>();
        
        _levelTimerSlider.maxValue = _levelController.GetLevelTime();
    }
    
    void Update()
    {
        _levelTimerSlider.value = Time.timeSinceLevelLoad;
        _timerFinished = Time.timeSinceLevelLoad >= _levelController.GetLevelTime();
        
        if (_timerFinished)
        {
            _gameManager.StopSpawners();
        }
    }
}
