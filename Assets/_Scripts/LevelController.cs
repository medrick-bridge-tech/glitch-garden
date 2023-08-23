using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelConfig _levelConfig;

    
    public float GetEnemySpawnRate()
    {
        return _levelConfig.EnemySpawnRate;
    }

    public float GetLevelTime()
    {
        return _levelConfig.LevelTime;
    }
}
