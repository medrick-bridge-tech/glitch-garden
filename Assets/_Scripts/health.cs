using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class health : MonoBehaviour
{
    public float Health;
    public void dealDamge(float damage)
    {
        Health -= damage;
        if (Health <= 0 )
        {
            DestroyObject();
        }
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
