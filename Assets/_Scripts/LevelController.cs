using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public LevelConfig _levelConfig;


    public float GetLevelTime()
    {
        return _levelConfig.LevelTime;
    }
    
    public float GetMinEnemySpawnDelay()
    {
        return _levelConfig.MinEnemySpawnDelay;
    }

    public float GetMaxEnemySpawnDelay()
    {
        return _levelConfig.MaxEnemySpawnDelay;
    }

    public void SetLevelConfig(LevelConfig levelConfig)
    {
        _levelConfig = levelConfig;
    }
}
