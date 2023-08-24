using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Slider _levelTimerSlider;
    private bool _timerFinished;
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
        _timerFinished = Time.timeSinceLevelLoad >= _levelController.GetLevelTime();
    }
}
