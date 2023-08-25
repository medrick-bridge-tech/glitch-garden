using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _levelCompleteCanvas;
    
    private LevelTimer _levelTimer;
    public int _numOfLiveAttackers;


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
    }
}
