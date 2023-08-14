using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Animator _anim;
    private Attacker _attacker;

    void Start()
    {
        _anim = GetComponent<Animator>();
        _attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (!obj.GetComponent<Defender>())
        {
            return;
        }
        _anim.SetBool("isAttacking", true);
        _attacker.Attack(obj);
    }
}
