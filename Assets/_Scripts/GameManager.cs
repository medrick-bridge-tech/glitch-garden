using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numOfLiveAttackers;
    
    [SerializeField] private GameObject _levelCompleteCanvas;
    
    private LevelTimer _levelTimer;


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
        numOfLiveAttackers++;
    }

    public void AttackerDied()
    {
        numOfLiveAttackers--;

        if (_levelTimer.timerFinished && numOfLiveAttackers == 0)
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
