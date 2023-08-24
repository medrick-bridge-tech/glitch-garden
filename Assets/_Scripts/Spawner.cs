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
    private bool _spawn = true;


    void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        
        _minSpawnDelay = _levelController.GetMinEnemySpawnDelay();
        _maxSpawnDelay = _levelController.GetMaxEnemySpawnDelay();
    }

    IEnumerator Start()
    {
        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnDelay, _maxSpawnDelay));
            var attackerIndex = Random.Range(0, _attackerPrefabArray.Length);
            SpawnAttacker(_attackerPrefabArray[attackerIndex]);
        }
    }
    
    void SpawnAttacker(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }
    
    public void StopSpawning()
    {
        _spawn = false;
    }
}
