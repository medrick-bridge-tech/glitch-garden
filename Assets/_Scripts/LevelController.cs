using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    
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
}
