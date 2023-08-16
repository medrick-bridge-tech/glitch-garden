using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Attacker : MonoBehaviour
{
    public float _currentSpeed, seenEverySecond;
    private GameObject _currentTarget;
    private Animator animator;
    private bool isMoving = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        
        if (!_currentTarget)
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
            animator.SetBool("isAttacking",false);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isAttacking", true);
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