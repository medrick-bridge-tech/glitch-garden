using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    [SerializeField] private float _spawnRate;
    private LevelController _levelController;

    void Start()
    {
        _levelController = FindObjectOfType<LevelController>();
        _spawnRate = _levelController.GetEnemySpawnRate();
        
        _spawnRate = 1 / _spawnRate;
    }
    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (IsTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject, transform, true) as GameObject;
        myAttacker.transform.position = transform.position;
    }
    
    bool IsTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySecond;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
             Debug.Log("Spawn rate");
        }

        float threshHold = spawnsPerSecond * Time.deltaTime;
        if (_spawnRate < threshHold)
        {
            return true;
        }
        else
        {
            return false;
        }
        return true;
    }
}
