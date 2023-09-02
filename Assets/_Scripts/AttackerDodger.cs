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
    private DamageDealer _damageDealer;


    void Start()
    {
        _damageDealer = GetComponent<DamageDealer>();
        _initalHealth = _damageDealer.CurrentHealth;
    }

    public void Dodge()
    {
        if (_damageDealer.CurrentHealth / _initalHealth <= _healthFraction)
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
