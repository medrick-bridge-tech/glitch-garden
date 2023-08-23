using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level Config",fileName = "Level")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private float _levelTime;
    [SerializeField] private float _enemySpawnRate;

    public float EnemySpawnRate => _enemySpawnRate;
    public float LevelTime => _levelTime;
}
