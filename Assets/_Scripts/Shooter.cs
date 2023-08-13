using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform direction;
    [SerializeField] private float force;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Fire()
    {
        bool isShooting = anim.GetBool("isShooting");
        if (isShooting)
        {
            GameObject newProjectile = Instantiate(projectile, direction.position, Quaternion.identity);
            Rigidbody2D arrowRigidbody = newProjectile.GetComponent<Rigidbody2D>();
            arrowRigidbody.AddForce(direction.right * force, ForceMode2D.Impulse);
        }
    }
}