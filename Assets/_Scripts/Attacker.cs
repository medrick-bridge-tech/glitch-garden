using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Attacker : MonoBehaviour
{
    public float _currentSpeed;
    private GameObject _currentTarget;
    private Animator animator;
    private bool isMoving = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
        }

        if (!_currentTarget)
        {
            animator.SetBool("isAttacking",false);
        }
    }
    
    public void SetSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (_currentTarget)
        {
            Health health = _currentTarget.GetComponent<Health>();
            isMoving = false;
            if (health)
            {
                health.dealDamge(damage);
            }
        }
    }

    public void Attack(GameObject obj)
    {
        _currentTarget = obj;
    }
}