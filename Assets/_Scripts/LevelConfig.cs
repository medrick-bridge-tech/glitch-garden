using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Config", fileName = "Level")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _levelTime;
    [SerializeField] private float _minEnemySpawnDelay;
    [SerializeField] private float _maxEnemySpawnDelay;

    public float LevelTime => _levelTime;

    public float MinEnemySpawnDelay => _minEnemySpawnDelay;

    public float MaxEnemySpawnDelay => _maxEnemySpawnDelay;
}
