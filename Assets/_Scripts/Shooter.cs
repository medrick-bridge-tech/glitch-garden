using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Transform _spawn;


    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Shoot();
        }
    }

    public void Shoot()
    { 
        GameObject newProjectile = Instantiate(_projectile, _spawn.position, Quaternion.identity);
    }
}