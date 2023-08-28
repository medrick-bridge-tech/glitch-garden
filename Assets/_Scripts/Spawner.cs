using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] Attacker[] _attackerPrefabArray;
    [SerializeField] float _minSpawnDelay;
    [SerializeField] float _maxSpawnDelay;
    
    private LevelController _levelController;
    private GameManager _gameManager;
    private bool _isTimeToSpawn = true;


    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        
        _levelController = FindObjectOfType<LevelController>();
        _minSpawnDelay = _levelController.GetMinEnemySpawnDelay();
        _maxSpawnDelay = _levelController.GetMaxEnemySpawnDelay();
    }

    IEnumerator Start()
    {
        while (_isTimeToSpawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            var attackerIndex = Random.Range(0, _attackerPrefabArray.Length);
            SpawnAttacker(_attackerPrefabArray[attackerIndex]);
        }
    }
    
    void SpawnAttacker(Attacker attacker)
    {
        if (_isTimeToSpawn)
        {
            Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
            newAttacker.transform.parent = transform;
        
            _gameManager.AttackerSpawned();
        }
    }
    
    public void StopSpawning()
    {
        _isTimeToSpawn = false;
    }
}
