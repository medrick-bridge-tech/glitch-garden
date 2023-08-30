using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [FormerlySerializedAs("projectile")] [SerializeField] private GameObject _projectile;
    [FormerlySerializedAs("spawn")] [SerializeField] private Transform _spawn;
    
    
    public void Shoot()
    { 
        GameObject newProjectile = Instantiate(_projectile, _spawn.position, Quaternion.identity);
    }
}