using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;
    
    
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
        if (Random.value * 2f < threshHold)
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
