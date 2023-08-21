using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public float health;
    public void dealDamge(float damage)
    {
        health -= damage;
        if (health <= 0 )
        {
            DestroyObject();
        }
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
