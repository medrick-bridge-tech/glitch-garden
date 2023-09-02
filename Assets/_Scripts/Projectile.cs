using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Attacker enemy = collider.gameObject.GetComponent<Attacker>();
        DamageDealer damageDealer = collider.gameObject.GetComponent<DamageDealer>();
        if (enemy && damageDealer)
        {
            damageDealer.DealDamge(_damage);
            Destroy(gameObject);
        }
    }
}
