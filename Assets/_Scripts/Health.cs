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

        var accelerator = GetComponent<Accelerator>();
        if (accelerator)
        {
            accelerator.AccelerateAttacker();
        }

        var duck = GetComponent<Duck>();
        if (duck)
        {
            duck.DuckReaction();
        }
    }
    
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
