using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    public GameObject projectile;
    public Transform spawn;
    public void Fire()
    { 
        GameObject newProjectile = Instantiate(projectile, spawn.position, Quaternion.identity);
    }
    
}