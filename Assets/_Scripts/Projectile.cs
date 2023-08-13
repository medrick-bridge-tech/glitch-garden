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
}
