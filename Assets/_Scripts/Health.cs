using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    [SerializeField] private float _currentHealth;

    public float CurrentHealth => _currentHealth;


    public void dealDamge(float damage)
    {
        _currentHealth -= damage;
        
        if (_currentHealth <= 0 )
        {
            DestroyObject();
        }

        var attackerAccelerator = GetComponent<AttackerAccelerator>();
        if (attackerAccelerator)
        {
            attackerAccelerator.Accelerate();
        }

        var attackerDodger = GetComponent<AttackerDodger>();
        if (attackerDodger)
        {
            attackerDodger.Dodge();
        }
    }
    
    private void DestroyObject()
    {
        var attacker = GetComponent<Attacker>();
        if (attacker)
        {
            FindObjectOfType<GameManager>().AttackerDied();
        }
        
        Destroy(gameObject);
    }
}
