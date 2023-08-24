using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public bool timerFinished;
    
    private Slider _levelTimerSlider;
    private LevelController _levelController;


    void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        _levelTimerSlider = GetComponent<Slider>();
        
        _levelTimerSlider.maxValue = _levelController.GetLevelTime();
    }

    void Update()
    {
        _levelTimerSlider.value = Time.timeSinceLevelLoad;
        timerFinished = Time.timeSinceLevelLoad >= _levelController.GetLevelTime();

        if (timerFinished)
        {
            FindObjectOfType<GameManager>().StopSpawners();
        }
    }
}
