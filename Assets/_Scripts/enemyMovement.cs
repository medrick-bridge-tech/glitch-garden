using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float _speed;
    private Vector2 targetPosition = new Vector2(9, -2);
    private Animator anim;
    private bool isMoving = true;
    

    void Start()
    {
        targetPosition = new Vector2(transform.position.x * (-10), transform.position.y);
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        if(isMoving)
        {
            MoveForward();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.tag = "Defence";
        if (other.tag != "Defence")
        {
            
            return;
        }
        else
        {
            anim.SetTrigger("isAttacking");
            isMoving = false;
        }
    }

    private void MoveForward()
    {
        Vector2 newPostion = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        transform.position = newPostion;
    }
}
