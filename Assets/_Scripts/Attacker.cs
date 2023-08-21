using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    
    public float _currentSpeed, seenEverySecond;
    
    private GameObject _currentTarget;
    private Animator animator;
    private float _timer = 0f;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAttackingEnemy() == false)
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
            animator.SetBool("isAttacking",false);
        }
        else
        {
            _timer += Time.deltaTime;
            
            if (_timer >= 0.3f)
            {
                StrikeCurrentTarget(_damage);
                _timer = 0f;
            }
        }

        bool IsAttackingEnemy()
        {
            return _currentTarget != null;
        }
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (_currentTarget)
        {
            Health health = _currentTarget.GetComponent<Health>();
            
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
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        
        animator.SetBool("isAttacking", true);
        Attack(obj);
    }
}