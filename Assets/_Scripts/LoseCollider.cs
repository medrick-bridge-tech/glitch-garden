using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        levelManager.LoadLevel("loseScene");
    }
}
