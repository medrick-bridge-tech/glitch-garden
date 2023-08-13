using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int damageCount;
    [SerializeField] GameObject projectiles;
    [SerializeField]  Transform firePoint;
    private Vector2 _direction;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Health health = gameObject.AddComponent<Health>();
        if (other.tag != "Enemy")
        {
            return;
        }
        else
        {
            health.dealDamge(damageCount);
            Destroy(gameObject);
        }
    }
    public void SetDirection(Vector2 direction)
    {
        if (_direction.x > 0)
        {
            _direction = Vector2.right;
        }
        else
        {
            _direction = Vector2.left;
        }
    }
    public void FireProjectile()
    {
        Instantiate(projectiles, firePoint.position, quaternion.identity);
        GetComponent<Projectile>().SetDirection(Vector2.MoveTowards(firePoint.position, Vector2.right, speed));
    }
}
