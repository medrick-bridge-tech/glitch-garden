using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Attacker : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _currentSpeed;
    
    private GameObject _currentTarget;
    private Animator _animator;
    private float _timer = 0f;

    public float CurrentSpeed
    {
        get => _currentSpeed;
        set => _currentSpeed = value;
    }


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAttackingEnemy() == false)
        {
            transform.Translate(Vector2.left * _currentSpeed * Time.deltaTime);
            _animator.SetBool("isAttacking",false);
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
            DamageDealer damageDealer = _currentTarget.GetComponent<DamageDealer>();
            
            if (damageDealer)
            {
                damageDealer.DealDamge(damage);
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
        
        _animator.SetBool("isAttacking", true);
        Attack(obj);
    }
}