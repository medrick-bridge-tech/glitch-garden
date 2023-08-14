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
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }
    bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();
        float meanSpawnDelay = attacker.seenEverySecond;
        float spawnsPerSecond = 1 / meanSpawnDelay;
        if (Time.deltaTime > meanSpawnDelay)
        {
             Debug.Log("Spawn rate");
        }

        float threshHold = spawnsPerSecond * Time.deltaTime;
        if (Random.value < threshHold)
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
