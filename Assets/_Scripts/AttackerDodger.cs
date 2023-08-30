using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerDodger : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] private float _healthFraction;
    
    private const float LOWEST_LANE_Y_POS = -3.5f;
    private const float VERTICAL_DISTANCE_BETWEEN_LANES = 1f;

    private float _initalHealth;
    private Health _health;


    void Start()
    {
        _health = GetComponent<Health>();
        _initalHealth = _health.health;
    }

    public void Dodge()
    {
        if (_health.health / _initalHealth <= _healthFraction)
        {
            if (transform.position.y <= LOWEST_LANE_Y_POS)
            {
                transform.position = new Vector3(transform.position.x, 
                    transform.position.y + VERTICAL_DISTANCE_BETWEEN_LANES, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, 
                    transform.position.y - VERTICAL_DISTANCE_BETWEEN_LANES, transform.position.z);
            }
        }
    }
}