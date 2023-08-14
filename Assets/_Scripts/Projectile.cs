using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed , damage;
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        EnemyMovement enemy = collider.gameObject.GetComponent<EnemyMovement>();
        Health health = collider.gameObject.GetComponent<Health>();
        if (enemy && health)
        {
            health.dealDamge(damage);
            Destroy(gameObject);
        }
    }
}
