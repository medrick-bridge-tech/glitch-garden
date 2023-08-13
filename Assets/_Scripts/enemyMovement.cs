using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float speed;
    private Vector2 _targetPosition = new Vector2(9, -2);
    private Animator _anim;
    private bool _isMoving = true;
    private GameObject _currentObject;


    void Start()
    {
        _targetPosition = new Vector2(transform.position.x * (-10), transform.position.y);
        _anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(_isMoving)
        {
            MoveForward();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Defence")
        {
            return;
        }
        else
        {
            _anim.SetTrigger("isAttacking");
            _isMoving = false;
        }
    }
    
    private void MoveForward()
    {
        Vector2 newPostion = Vector2.MoveTowards(transform.position, _targetPosition, speed * Time.deltaTime);
        transform.position = newPostion;
    }

    private void StrikeCurrentObjcet(float damage)
    {
        if (_currentObject)
        {
            Health health =  _currentObject.GetComponent<Health>();
            if (health)
            {
                health.dealDamge(damage);
            }
        }
        
    }
}
