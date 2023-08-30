using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerAccelerator : MonoBehaviour
{
    [Range(1f, 2f)]
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private float _speedLimit;

    private float _initalHealth;
    private Health _health;
    private Attacker _attacker;


    void Start()
    {
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
        _initalHealth = _health.health;
    }
    
    public void Accelerate()
    {
        if (_attacker.CurrentSpeed <= _speedLimit)
        {
            _attacker.CurrentSpeed += (_initalHealth / _health.health * _speedMultiplier);
        }
    }
}
